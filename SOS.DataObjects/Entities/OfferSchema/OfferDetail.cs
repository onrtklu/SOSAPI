namespace SOS.DataObjects.Entities.OfferSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.RestaurantSchema;
    using System;

    public partial class OfferDetail : BaseEntity
    {
        public int? OfferId { get; set; }

        public int? MenuItemId { get; set; }

        public int? Quantity { get; set; }

        public DateTime? Datetime { get; set; }

        public virtual Offer Offer { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}
