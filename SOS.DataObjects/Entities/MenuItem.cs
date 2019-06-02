using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class MenuItem : BaseEntity
    {
        public string ItemName { get; set; }
        public int Category_Id { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Receipe { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int Restaurant_Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
