using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Menu
{
    public interface IMenuManager
    {
        ISosResult GetMenuItem(int Id);
        ISosResult GetMenuItemList(int Restaurant_Id);
        ISosResult GetMenuCategoryList(int Restaurant_Id);
        ISosResult GetMenuItemListByCategory(int Category_Id);
    }
}
