using SOS.DataObjects.ComplexTypes.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    /// <summary>
    /// Menu with menu items
    /// </summary>
    public class MenuDto
    {
        public RestaurantDto Restaurant { get; set; }
        public IEnumerable<Menu_MenuItemDto> MenuItems { get; set; }
    }
}
