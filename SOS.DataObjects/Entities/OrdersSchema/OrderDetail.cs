namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.RestaurantSchema;

    public partial class OrderDetail : BaseEntity
    {
        public int? Order_Id { get; set; }

        public int? MenuItem_Id { get; set; }

        public int? Quantity { get; set; }

        public string OrderNote { get; set; }

        public decimal? ItemPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? PaymentType_Id { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual PaymentType PaymentType { get; set; }
    }
}
