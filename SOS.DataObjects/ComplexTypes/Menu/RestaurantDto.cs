using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string CoverImageUrl { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantLogoImageUrl { get; set; }
        public decimal Rate { get; set; }
        public string RestaurantTypeName { get; set; }
        public int EstimatedServiceTime { get; set; }
    }
}
