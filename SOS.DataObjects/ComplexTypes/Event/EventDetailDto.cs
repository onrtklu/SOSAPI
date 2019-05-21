using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Event
{
    public class EventDetailDto
    {
        public int EventID { get; set; }
        public string HallName { get; set; }
        public string PlayName { get; set; }
        public DateTime EventDate { get; set; }

        public string EventName => PlayName + " " + EventDate.ToString("dd.MM.yyyy mm:HH");
    }
}
