using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    public class Menu_MenuItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemIngredients { get; set; }
        public decimal Price { get; set; }
    }
}
