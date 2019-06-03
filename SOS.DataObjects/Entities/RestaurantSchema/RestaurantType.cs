using SOS.Core.Entities;
using System.Collections.Generic;

namespace SOS.DataObjects.Entities.RestaurantSchema
{
    public class RestaurantType : BaseEntity
    {
        public RestaurantType()
        {
            Restaurant = new HashSet<Restaurant>();
        }
        
        public string RestaurantTypeName { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
