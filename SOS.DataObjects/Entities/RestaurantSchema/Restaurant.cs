using SOS.Core.Entities;
using SOS.DataObjects.Entities.ConstantSchema;
using SOS.DataObjects.Entities.CreditSchema;
using SOS.DataObjects.Entities.OrdersSchema;
using SOS.DataObjects.Entities.UsersSchema;
using System;
using System.Collections.Generic;
namespace SOS.DataObjects.Entities.RestaurantSchema
{

    public partial class Restaurant : BaseEntity
    {
        public Restaurant()
        {
            OrderCredit = new HashSet<OrderCredit>();
            Orders = new HashSet<Orders>();
            MenuCategory = new HashSet<MenuCategory>();
            MenuItem = new HashSet<MenuItem>();
            RestaurantDetail = new HashSet<RestaurantDetail>();
            RestaurantUser = new HashSet<RestaurantUser>();
        }
        
        public string RestaurantName { get; set; }

        public int? City_Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ConfirmationKey { get; set; }

        public int? RestaurantType_Id { get; set; }

        public DateTime? Datetime { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<OrderCredit> OrderCredit { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<MenuCategory> MenuCategory { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }

        public virtual RestaurantType RestaurantType { get; set; }

        public virtual ICollection<RestaurantDetail> RestaurantDetail { get; set; }

        public virtual ICollection<RestaurantUser> RestaurantUser { get; set; }
    }
}
