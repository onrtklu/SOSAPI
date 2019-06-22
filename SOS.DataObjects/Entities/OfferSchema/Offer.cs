namespace SOS.DataObjects.Entities.OfferSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.CustomerSchema;
    using SOS.DataObjects.Entities.OrdersSchema;
    using System;
    using System.Collections.Generic;

    public partial class Offer : BaseEntity
    {
        public Offer()
        {
            OfferDetail = new HashSet<OfferDetail>();
        }

        public DateTime? StartOfferDatetime { get; set; }

        public DateTime? FinishOfferDatetime { get; set; }

        public int? OfferPaymentTypeId { get; set; }

        public int? Customer_Id { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual ICollection<OfferDetail> OfferDetail { get; set; }
    }
}
