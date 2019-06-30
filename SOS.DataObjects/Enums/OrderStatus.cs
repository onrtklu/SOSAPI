using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.Enums
{
    public enum OrderStatus
    {
        SiparisBekleniyor = 1,
        SiparisAlindi = 2,
        SiparisHazirlaniyor = 3,
        HazirlamaHatasi = 4,
        SiparisTeslimEdiliyor = 5,
        SiparisTeslimEdildi = 6
    }
}
