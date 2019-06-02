using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Event
{
    public class EventInsertDto
    {
        public int PlayID { get; set; }
        public int HallID { get; set; }
        public DateTime EventDate { get; set; }
    }
}
