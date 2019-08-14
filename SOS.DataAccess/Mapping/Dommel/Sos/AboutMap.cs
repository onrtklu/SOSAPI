using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Sos
{
    public class AboutMap : DommelEntityMap<DataObjects.Entities.SosSchema.About>
    {
        public AboutMap()
        {
            ToTable("About", "Sos");
        }
    }
}
