using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Restaurant
{
    public class MenuItemMap : DommelEntityMap<MenuItem>
    {
        public MenuItemMap()
        {
            ToTable("MenuItem", "Restaurant");

            Map(s => s.MenuCategoryId).ToColumn("Category_Id");

            Map(s => s.OfferDetail).Ignore();
            Map(s => s.OrderDetails).Ignore();
            Map(s => s.MenuCategory).Ignore();
            Map(s => s.Restaurant).Ignore();
        }
    }
}
