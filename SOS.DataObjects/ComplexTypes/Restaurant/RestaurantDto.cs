using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Restaurant
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string CoverImageUrl { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantShortDescription { get; set; }
        public string RestaurantLogoImageUrl { get; set; }
        public decimal Rate { get; set; }
        public string RestaurantTypeName { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
    }
}
