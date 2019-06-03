using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.UsersSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Users
{
    public class RestaurantUserMap : DommelEntityMap<RestaurantUser>
    {
        public RestaurantUserMap()
        {
            ToTable("RestaurantUser", "Users");

            Map(s => s.Restaurant).Ignore();
            Map(s => s.Users).Ignore();
        }
    }
}
