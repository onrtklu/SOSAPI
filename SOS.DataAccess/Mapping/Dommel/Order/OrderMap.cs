using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Order
{
    public class OrderMap : DommelEntityMap<DataObjects.Entities.OrdersSchema.Order>
    {
        public OrderMap()
        {
            ToTable("Orders", "Orders");

            Map(s => s.OrderCredit).Ignore();
            Map(s => s.Customers).Ignore();
            Map(s => s.OnlinePaymentOrders).Ignore();
            Map(s => s.OrderDetails).Ignore();
            Map(s => s.OrderStatus).Ignore();
            Map(s => s.Restaurant).Ignore();
            Map(s => s.RestaurantComments).Ignore();
            Map(s => s.PaymentType).Ignore();
        }
    }
}
