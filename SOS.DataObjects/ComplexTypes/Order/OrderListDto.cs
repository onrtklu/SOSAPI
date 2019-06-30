using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Order
{
    public class OrderListDto
    {
        public int Order_Id { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderStatusName { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
