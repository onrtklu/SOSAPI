using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }
        public int City_Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ConfirmationKey { get; set; }
        public int RestaurantType_Id { get; set; }
        public DateTime DateTime { get; set; }
    }
}
