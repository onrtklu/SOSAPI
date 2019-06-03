using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities.UsersSchema
{
    public class Users : BaseEntity
    {
        public Users()
        {
            RestaurantUser = new HashSet<RestaurantUser>();
        }
        
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public int? UserAuth_Id { get; set; }

        public string ConfirmationKey { get; set; }

        public virtual Authority Authority { get; set; }

        public virtual ICollection<RestaurantUser> RestaurantUser { get; set; }
    }
}
