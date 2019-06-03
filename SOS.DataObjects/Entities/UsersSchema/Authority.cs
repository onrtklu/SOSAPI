using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities.UsersSchema
{
    public class Authority : BaseEntity
    {
        public Authority()
        {
            Users = new HashSet<Users>();
        }
        
        public string AuthorityName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
