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
        public decimal? SubTotalPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? EstimatedDeliveryTime { get; set; }
        public IEnumerable<OfferMenuItemList> MenuItems { get; set; }
        public IEnumerable<OfferPageCreditListDto> CreditList { get; set; }
    }
}
