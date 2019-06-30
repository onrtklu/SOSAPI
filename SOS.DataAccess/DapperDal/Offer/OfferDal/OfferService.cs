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

        // Offer tablosunda kayıt varsa id'sini döndürür
        public int? GetOffer(int customer_Id, int restaurant_Id)
        {
            var item = this.Select(s => s.Customer_Id == customer_Id && s.Restaurant_Id == restaurant_Id).FirstOrDefault();

            return item?.Id;
        }
    }
}
