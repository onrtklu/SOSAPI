using SOS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Entities
{
    public class Event : BaseEntity
    {
        public int? HallID { get; set; }
        public int? PlayID { get; set; }
        public DateTime EventDate { get; set; }
    }
}
