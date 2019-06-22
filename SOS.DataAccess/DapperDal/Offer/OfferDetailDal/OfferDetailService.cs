using Dapper;
using SOS.Core.DataAccess.Dapper;
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

        public MenuItem GetMenuItemFromOffer(int menuItemId, int customerId)
        {
            var result = _connection.QuerySingle<MenuItem>("Offer.GetMenuItem",
                new { MenuItem_Id = menuItemId, Customer_Id = customerId },
                _transaction,
                commandType: CommandType.StoredProcedure);

            return result;
        }

        public IEnumerable<OfferMenuItemList> GetOfferMenuItemList(int customerId)
        {
            var item = _connection.Query<OfferMenuItemList>("Offer.GetOfferMenuItemList",
                new { Customer_ID = customerId },
                _transaction,
                commandType: CommandType.StoredProcedure);
            
            return item;
        }
    }
}
