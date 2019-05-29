using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.HateoasType
{
    public interface ILink
    {
        string Href { get; set; }
        string Rel { get; set; }
        string method { get; set; }
    }
}
