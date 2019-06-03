using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.UsersSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Users
{
    public class AuthorityMap : DommelEntityMap<Authority>
    {
        public AuthorityMap()
        {
            ToTable("Authority", "Users");

            Map(s => s.AuthorityName).ToColumn("AuthorityName");
        }   
    }
}
