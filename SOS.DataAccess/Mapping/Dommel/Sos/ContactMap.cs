using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Sos
{
    public class ContactMap : DommelEntityMap<DataObjects.Entities.SosSchema.Contact>
    {
        public ContactMap()
        {
            ToTable("Contact", "Sos");
        }
    }
}
