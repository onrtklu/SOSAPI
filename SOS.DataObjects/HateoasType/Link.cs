using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.HateoasType
{
    public class Link : ILink
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string method { get; set; }
    }
}
