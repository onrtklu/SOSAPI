using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Offer
{
    public class OfferMap : DommelEntityMap<DataObjects.Entities.OfferSchema.Offer>
    {
        public OfferMap()
        {
            ToTable("Offer", "Offer");

            Map(s => s.OfferPaymentTypeId).ToColumn("OfferPaymentType_Id");

            Map(s => s.Customers).Ignore();
            Map(s => s.PaymentType).Ignore();
            Map(s => s.OfferDetail).Ignore();
        }
    }
}
