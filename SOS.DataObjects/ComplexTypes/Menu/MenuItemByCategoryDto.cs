using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    /// <summary>
    /// Menu items by category
    /// </summary>
    public class MenuItemByCategoryDto
    {
        public RestaurantDto Restaurant { get; set; }
        public Menu_CategoryDto Category { get; set; }
        public IEnumerable<Menu_MenuItemDto> MenuItems { get; set; }
    }
}
