using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class MenuCategory : BaseEntity
    {
        public int Parent_Id { get; set; }
        public string CategoryName { get; set; }
        public int Restaurant_Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
