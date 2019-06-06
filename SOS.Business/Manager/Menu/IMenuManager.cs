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
        ISosResult GetMenuList(int Restaurant_Id);
        ISosResult GetMenuCategoryList(int Restaurant_Id);
        ISosResult GetMenuItem(int Id);
    }
}
