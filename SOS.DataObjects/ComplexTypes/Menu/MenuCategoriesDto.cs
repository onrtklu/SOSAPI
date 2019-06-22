using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    /// <summary>
    /// Menu with menu categories
    /// </summary>
    public class MenuCategoriesDto
    {
        public RestaurantDto Restaurant { get; set; }
        public IEnumerable<Menu_CategoryDto> CategoryItems { get; set; }
    }
}
