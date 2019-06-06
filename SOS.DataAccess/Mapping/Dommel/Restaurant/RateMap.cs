using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Restaurant
{
    public class RateMap : DommelEntityMap<Rate>
    {
        public RateMap()
        {
            ToTable("Rate", "Restaurant");

            Map(s => s.RestaurantComments).Ignore();
        }
    }
}
