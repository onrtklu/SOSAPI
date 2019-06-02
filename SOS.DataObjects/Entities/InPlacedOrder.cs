using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class InPlacedOrder : BaseEntity
    {
        public int PlacedOrder_Id { get; set; }
        public int MenuItem_Id { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int PaymentType_Id { get; set; }
    }
}
