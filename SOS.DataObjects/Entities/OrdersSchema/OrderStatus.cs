namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using System.Collections.Generic;

    public class OrderStatus : BaseEntity
    {
        public OrderStatus()
        {
            Orders = new HashSet<Orders>();
        }

        public string OrderStatusName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
