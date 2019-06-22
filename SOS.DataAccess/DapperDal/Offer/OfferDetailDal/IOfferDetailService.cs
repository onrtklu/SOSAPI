using SOS.Core.DataAccess;
using SOS.DataObjects.Entities.RestaurantSchema;
using SOS.DataObjects.Entities.OfferSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOS.DataObjects.ComplexTypes.Offer;

namespace SOS.DataAccess.DapperDal.Offer.OfferDetailDal
{
    public interface IOfferDetailService : IGenericRepository<OfferDetail>
    {
        bool IsMenuItemAdded(int menuItemId, int customerId);
        MenuItem GetMenuItemFromOffer(int menuItemId, int customerId);
        IEnumerable<OfferMenuItemList> GetOfferMenuItemList(int customerId);
    }
}
