namespace SOS.DataObjects.Entities.RestaurantSchema
{
    using SOS.Core.Entities;
    using System;

    public class RestaurantDetail : BaseEntity
    {
        public int? RestaurantId { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string OpeningHours { get; set; }

        public string ClosingHours { get; set; }

        public bool? Smoking { get; set; }

        public bool? Alcohol { get; set; }

        public DateTime? Datetime { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
