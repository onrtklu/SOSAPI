namespace SOS.DataObjects.Entities.RestaurantSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.CustomerSchema;
    using SOS.DataObjects.Entities.OrdersSchema;
    using System;
    using System.Collections.Generic;

    public class RestaurantComments : BaseEntity
    {
        public RestaurantComments()
        {
            Rate = new HashSet<Rate>();
        }
        
        public int? Order_Id { get; set; }

        public int? Customer_Id { get; set; }

        public string CommentText { get; set; }

        public DateTime? OrderDate { get; set; }

        public bool? Complaint { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual ICollection<Rate> Rate { get; set; }
    }
}
