namespace SOS.DataObjects.Entities.OrdersSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.CreditSchema;
    using SOS.DataObjects.Entities.CustomerSchema;
    using SOS.DataObjects.Entities.RestaurantSchema;
    using System;
    using System.Collections.Generic;

    public class Order : BaseEntity
    {
        public Order()
        {
            OrderCredit = new HashSet<OrderCredit>();
            OnlinePaymentOrders = new HashSet<OnlinePaymentOrders>();
            OrderDetails = new HashSet<OrderDetail>();
            RestaurantComments = new HashSet<RestaurantComments>();
        }
        
        public int? Restaurant_Id { get; set; }

        public DateTime? OrderTime { get; set; }

        public int? EstimatedDeliveryTime { get; set; }

        public DateTime? ActualDeliveryTime { get; set; }

        public int? Customer_Id { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? Discount { get; set; }

        public decimal? FinalPrice { get; set; }

        public string Comments { get; set; }

        public bool? IsSuccess { get; set; }

        public int? OrderStatus_Id { get; set; }

        public int? PaymentType_Id { get; set; }

        public DateTime? Datetime { get; set; }

        public virtual ICollection<OrderCredit> OrderCredit { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual ICollection<OnlinePaymentOrders> OnlinePaymentOrders { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<RestaurantComments> RestaurantComments { get; set; }

        public virtual PaymentType PaymentType { get; set; }
    }
}
