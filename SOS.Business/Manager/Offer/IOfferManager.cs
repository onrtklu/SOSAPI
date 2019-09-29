using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Offer
{
    public interface IOfferManager
    {
        ISosResult GetOfferList(int customer_Id, int restaurant_Id);

        ISosResult AddOfferItem(MenuItemDtoInsert menuItem, int customer_Id, int restaurant_Id, int table_Id);

        ISosResult UpdateOfferItem(MenuItemDtoUpdate menuItem, int customer_Id, int restaurant_Id);

        ISosResult DeleteOfferItem(int menuItem_Id, int customer_Id, int restaurant_Id);
    }
}
