namespace SOS.DataObjects.Entities.OfferSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.CustomerSchema;
    using SOS.DataObjects.Entities.OrdersSchema;
    using System;
    using System.Collections.Generic;

    public partial class Offer : BaseEntity
    {
        public int Restaurant_Id { get; set; }

        public DateTime? StartOfferDatetime { get; set; }

        public DateTime? FinishOfferDatetime { get; set; }

        public int? Customer_Id { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual OfferDetail OfferDetail { get; set; }
    }
}
