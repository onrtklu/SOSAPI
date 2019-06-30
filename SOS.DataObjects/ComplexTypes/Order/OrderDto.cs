using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Order
{
    public class OrderDto
    {
        public int Order_Id { get; set; }
        public int OrderStatus_Id { get; set; }
        public string OrderStatusName { get; set; }
        public int PaymentType_Id { get; set; }
        public string PaymentTypeName { get; set; }
        public int EstimatedDeliveryTime { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public IEnumerable<OrderMenuItemList> MenuItems { get; set; }
        public IEnumerable<OrderPageCreditListDto> CreditList { get; set; }
    }
}
