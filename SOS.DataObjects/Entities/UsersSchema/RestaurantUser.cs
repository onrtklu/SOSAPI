using SOS.Core.Entities;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities.UsersSchema
{
    public class RestaurantUser : BaseEntity
    {
        public int? Restaurant_Id { get; set; }

        public int? User_Id { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual Users Users { get; set; }
    }
}
