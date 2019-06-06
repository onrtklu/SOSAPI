using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Restaurant
{
    public class MenuCategoryMap : DommelEntityMap<MenuCategory>
    {
        public MenuCategoryMap()
        {
            ToTable("MenuCategory", "Restaurant");

            Map(s => s.MenuCategorySub).Ignore();
            Map(s => s.MenuCategoryTop).Ignore();
            Map(s => s.Restaurant).Ignore();
            Map(s => s.MenuItem).Ignore();
        }
    }
}
