using Dommel;
using SOS.Core.DataAccess.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Offer.OfferDal
{
    public class OfferService : DapperGenericRepository<DataObjects.Entities.OfferSchema.Offer>, IOfferService
    {
        public OfferService(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
