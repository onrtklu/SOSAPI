using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.ConstantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Constant
{
    public class CityMap : DommelEntityMap<City>
    {
        public CityMap()
        {
            ToTable("City", "Constant");

            Map(s => s.Restaurant).Ignore();
            Map(s => s.Customers).Ignore();
        }
    }
}
