namespace SOS.DataObjects.Entities.RestaurantSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.OfferSchema;
    using SOS.DataObjects.Entities.OrdersSchema;
    using System.Collections.Generic;

    public class MenuItem : BaseEntity
    {
        public MenuItem()
        {
            OfferDetail = new HashSet<OfferDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }
        
        public string ItemName { get; set; }

        public int? Category_Id { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Receipe { get; set; }

        public decimal? Price { get; set; }

        public bool? IsActive { get; set; }

        public int? Restaurant_Id { get; set; }

        public virtual ICollection<OfferDetail> OfferDetail { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual MenuCategory MenuCategory { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
