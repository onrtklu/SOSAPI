using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.HateoasType
{
    public class LinkHelper 
    {
        public ISosResult Value { get; set; }
        public List<Link> Links { get; set; }

        public LinkHelper()
        {
            Links = new List<Link>();
        }

        public LinkHelper(ISosResult item) : base()
        {
            Value = item;
            Links = new List<Link>();

        }
    }
}
