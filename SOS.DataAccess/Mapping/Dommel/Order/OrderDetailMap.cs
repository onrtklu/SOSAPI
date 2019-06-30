using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Order
{
    public class OrderDetailMap : DommelEntityMap<DataObjects.Entities.OrdersSchema.OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("OrderDetail", "Orders");

            Map(s => s.MenuItem).Ignore();
            Map(s => s.Orders).Ignore();
        }
    }
}
