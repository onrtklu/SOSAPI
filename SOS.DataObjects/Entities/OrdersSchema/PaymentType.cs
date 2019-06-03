namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.OfferSchema;
    using System.Collections.Generic;

    public class PaymentType : BaseEntity
    {
        public PaymentType()
        {
            Offer = new HashSet<Offer>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string PaymentTypeName { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
