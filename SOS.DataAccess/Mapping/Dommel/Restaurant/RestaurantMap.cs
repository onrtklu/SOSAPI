using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Restaurant
{
    public class RestaurantMap: DommelEntityMap<SOS.DataObjects.Entities.RestaurantSchema.Restaurant>
    {
        public RestaurantMap()
        {
            ToTable("Restaurant", "Restaurant");

            Map(s => s.OrderCredit).Ignore();
            Map(s => s.Orders).Ignore();
            Map(s => s.MenuCategory).Ignore();
            Map(s => s.MenuItem).Ignore();
            Map(s => s.RestaurantDetail).Ignore();
            Map(s => s.RestaurantUser).Ignore();
            Map(s => s.RestaurantType).Ignore();
        }
    }
}
