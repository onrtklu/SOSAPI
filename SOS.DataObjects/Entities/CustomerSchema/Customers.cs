namespace SOS.DataObjects.Entities.CustomerSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.ConstantSchema;
    using SOS.DataObjects.Entities.CreditSchema;
    using SOS.DataObjects.Entities.OfferSchema;
    using SOS.DataObjects.Entities.OrdersSchema;
    using SOS.DataObjects.Entities.RestaurantSchema;
    using System;
    using System.Collections.Generic;

    public class Customers : BaseEntity
    {
        public Customers()
        {
            CustomerCredit = new HashSet<CustomerCredit>();
            OrderCredit = new HashSet<OrderCredit>();
            SocialMedia = new HashSet<SocialMedia>();
            Offer = new HashSet<Offer>();
            Orders = new HashSet<Orders>();
            RestaurantComments = new HashSet<RestaurantComments>();
        }

        public string CustomerName { get; set; }

        public int? City_Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ConfirmationKey { get; set; }

        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? ActiveDate { get; set; }

        public DateTime? Datetime { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<CustomerCredit> CustomerCredit { get; set; }

        public virtual ICollection<OrderCredit> OrderCredit { get; set; }

        public virtual ICollection<SocialMedia> SocialMedia { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<RestaurantComments> RestaurantComments { get; set; }
    }
}
