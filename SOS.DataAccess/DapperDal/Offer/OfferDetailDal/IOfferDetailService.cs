using SOS.Core.DataAccess;
using SOS.DataObjects.Entities.OfferSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOS.DataObjects.ComplexTypes.Offer;
using SOS.DataObjects.ComplexTypes.MenuItem;

namespace SOS.DataAccess.DapperDal.Offer.OfferDetailDal
{
    public interface IOfferDetailService : IGenericRepository<OfferDetail>
    {
        bool IsMenuItemAdded(int menuItemId, int customerId);
        MenuItemDto GetMenuItemFromOffer(int menuItemId, int customerId);
        IEnumerable<OfferMenuItemList> GetOfferMenuItemList(int customerId, int restaurant_Id);
        void OfferDetailDelete(int offer_Id, int menuItem_Id);
    }
}
