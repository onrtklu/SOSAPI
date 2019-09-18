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
        ISosResult GetMenuItem(int Id, int customer_Id);
        ISosResult GetMenuItemList(int Restaurant_Id);
    }
}
