using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel
{
    public class EventMap : DommelEntityMap<Event>
    {
        public EventMap()
        {
            ToTable("Event");
        }
    }
}
