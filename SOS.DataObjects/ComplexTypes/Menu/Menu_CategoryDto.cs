using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    public class Menu_CategoryDto
    {
        public Menu_CategoryDto()
        {
            MenuItems = new List<Menu_MenuItemDto>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public List<Menu_MenuItemDto> MenuItems { get; set; }
    }
}
