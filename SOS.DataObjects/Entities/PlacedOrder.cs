using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class PlacedOrder : BaseEntity
    {
        public int Restaurant_Id { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime EstimatedDeliveryTime { get; set; }
        public DateTime ActualDeliveryTime { get; set; }
        public int Customer_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
        public string Comments { get; set; }
        public bool IsSuccess { get; set; }
        public int OrderStatus_Id { get; set; }
        public DateTime Datetime { get; set; }
    }
}
