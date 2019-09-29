using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Order
{
    public class OrderMenuItemList
    {
        public int MenuItem_Id { get; set; }
        public string ItemName { get; set; }
        public string ItemIngredients { get; set; }
        public string OrderNote { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
