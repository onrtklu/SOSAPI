using SOS.DataObjects.ComplexTypes.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Offer
{
    public class OfferDto
    {
        public IEnumerable<OfferMenuItemList> MenuItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
