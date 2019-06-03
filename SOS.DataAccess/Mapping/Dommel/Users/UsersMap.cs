using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Users
{
    public class UsersMap : DommelEntityMap<SOS.DataObjects.Entities.UsersSchema.Users>
    {
        public UsersMap()
        {
            ToTable("Users", "Users");

            Map(s => s.RestaurantUser).Ignore();
            Map(s => s.Authority).Ignore();
        }
    }
}
