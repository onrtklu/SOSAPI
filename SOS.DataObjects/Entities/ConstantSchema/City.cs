namespace SOS.DataObjects.Entities.ConstantSchema
{
    using SOS.Core.Entities;
    using SOS.DataObjects.Entities.CustomerSchema;
    using SOS.DataObjects.Entities.RestaurantSchema;
    using System.Collections.Generic;

    public class City : BaseEntity
    {
        public City()
        {
            Customers = new HashSet<Customers>();
            Restaurant = new HashSet<Restaurant>();
        }
        
        public string CityName { get; set; }

        public string ZipCode { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
