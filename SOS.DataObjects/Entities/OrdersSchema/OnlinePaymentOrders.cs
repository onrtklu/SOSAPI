namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using System;

    public partial class OnlinePaymentOrders : BaseEntity
    {
        public string PaymentKey { get; set; }

        public int? PaymentStatus_Id { get; set; }

        public int? Order_Id { get; set; }

        public string PrevisionKey { get; set; }

        public string PaymentToken { get; set; }

        public DateTime? PrevisionBeginDatetime { get; set; }

        public DateTime? PrevisionEndDatetime { get; set; }

        public DateTime? PaymentSuccessfulDatetime { get; set; }

        public bool? PaymentValidate { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
