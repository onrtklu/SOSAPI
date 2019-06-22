using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.DapperDal.MenuCategoryDal;
using SOS.DataAccess.DapperDal.MenuItemDal;
using SOS.DataAccess.DapperDal.Offer.OfferDal;
using SOS.DataAccess.DapperDal.Offer.OfferDetailDal;
using SOS.DataAccess.DapperDal.RestaurantDal;
using SOS.DataAccess.Mapping.Dommel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Uow
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private bool _disposed;

        private IEventService _eventService;
        private IMenuItemService _menuItemService;
        private IRestaurantService _restaurantService;
        private IMenuCategoryService _menuCategoryService;
        private IOfferService _offerService;
        private IOfferDetailService _offerDetailService;

        public UnitOfWork()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = null;
        }

        public IEventService EventService => _eventService ?? (_eventService = new EventService(_transaction));
        public IMenuItemService MenuItemService => _menuItemService ?? (_menuItemService = new MenuItemService(_transaction));
        public IRestaurantService RestaurantService => _restaurantService ?? (_restaurantService = new RestaurantService(_transaction));
        public IMenuCategoryService MenuCategoryService => _menuCategoryService ?? (_menuCategoryService = new MenuCategoryService(_transaction));
        public IOfferService OfferService => _offerService ?? (_offerService = new OfferService(_transaction));
        public IOfferDetailService OfferDetailService => _offerDetailService ?? (_offerDetailService = new OfferDetailService(_transaction));

        public void BeginTransaction() => _transaction = _connection.BeginTransaction();

        public void Commit()
        {
            if (_transaction == null)
                return;

            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                //_transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _eventService = null;
            _eventService = null;
            _menuItemService = null;
            _restaurantService = null;
            _menuCategoryService = null;
            _offerService = null;
            _offerDetailService = null;
    }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
