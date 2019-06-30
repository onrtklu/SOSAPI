using SOS.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Offer.OfferDal
{
    public interface IOfferService : IGenericRepository<DataObjects.Entities.OfferSchema.Offer>
    {
        int? GetOffer(int customer_Id, int restaurant_Id);
    }
}
