using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.MenuItem
{
    public class MenuItemDto
    {
        public MenuItemDto()
        {
            Quantity = 1;
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }

    public class MenuItemDtoInsert
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }

    public class MenuItemDtoUpdate
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}
