namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using System.Collections.Generic;

    public class PaymentStatus : BaseEntity
    {
        public PaymentStatus()
        {
            OnlinePaymentOrders = new HashSet<OnlinePaymentOrders>();
        }

        public string PaymentStatusName { get; set; }

        public virtual ICollection<OnlinePaymentOrders> OnlinePaymentOrders { get; set; }
    }
}
