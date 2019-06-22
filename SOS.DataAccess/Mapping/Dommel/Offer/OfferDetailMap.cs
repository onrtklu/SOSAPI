using Dapper.FluentMap.Dommel.Mapping;
using SOS.DataObjects.Entities.OfferSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Offer
{
    public class OfferDetailMap : DommelEntityMap<OfferDetail>
    {
        public OfferDetailMap()
        {
            ToTable("OfferDetail", "Offer");

            Map(s => s.OfferId).ToColumn("Offer_Id");
            Map(s => s.MenuItemId).ToColumn("MenuItem_Id");

            Map(s => s.Offer).Ignore();
            Map(s => s.MenuItem).Ignore();
        }
    }
}
