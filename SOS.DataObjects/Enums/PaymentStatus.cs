using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Enums
{
    public enum PaymentStatus
    {
        Bekliyor = 1,
        BeklemeHatasi = 2,
        OdemeReddedildi = 3,
        GeriOdemeYapildi = 4,
        OdemeBasarili = 5
    }
}
