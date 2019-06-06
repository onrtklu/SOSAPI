using Dommel;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.MenuItemDal
{
    public class MenuItemService : DapperGenericRepository<MenuItem>, IMenuItemService
    {
        public MenuItemService(IDbTransaction transaction) : base(transaction)
        {
        }

        public MenuItem GetWithCategory(int id)
        {
            var item = _connection.Get<MenuItem, MenuCategory, MenuItem>(id, (menuItem, menuCategory) =>
            {
                menuItem.MenuCategory = menuCategory;
                return menuItem;
            });

            return item;
        }
    }
}
