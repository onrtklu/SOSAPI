using Dapper;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.ComplexTypes.Offer;
using SOS.DataObjects.Entities.OfferSchema;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Offer.OfferDetailDal
{
    public class OfferDetailService : DapperGenericRepository<OfferDetail>, IOfferDetailService
    {
        public OfferDetailService(IDbTransaction transaction) : base(transaction)
        {
        }

        public bool IsMenuItemAdded(int menuItemId, int customerId)
        {
            var result = _connection.QuerySingle<bool>("Offer.IsMenuItemAdded",
                new { MenuItem_Id = menuItemId, Customer_Id  = customerId},
                _transaction,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public MenuItemDto GetMenuItemFromOffer(int menuItemId, int customerId)
        {
            var result = _connection.QuerySingle<MenuItemDto>("Offer.GetMenuItem",
                new { MenuItem_Id = menuItemId, Customer_Id = customerId },
                _transaction,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public IEnumerable<OfferMenuItemList> GetOfferMenuItemList(int customerId, int restaurant_Id)
        {
            var item = _connection.Query<OfferMenuItemList>("Offer.GetOfferMenuItemList",
                new { Customer_ID = customerId, Restaurant_Id = restaurant_Id },
                _transaction,
                commandType: CommandType.StoredProcedure);
            
            return item;
        }

        public void OfferDetailDelete(int offer_Id, int menuItem_Id)
        {
            this.DeleteMultiple(s => s.OfferId == offer_Id && s.MenuItemId == menuItem_Id);

            int offerDetailCount = _connection.ExecuteScalar<int>("SELECT COUNT(Id) FROM Offer.OfferDetail WHERE Offer_Id = @Offer_Id",
                new { Offer_Id = offer_Id },
                transaction: _transaction);

            if (offerDetailCount == 0)
            {
                _connection.Execute("DELETE FROM Offer.Offer WHERE Id = @Offer_Id",
                    new { Offer_Id = offer_Id },
                    transaction: _transaction);
            }
        }
    }
}
