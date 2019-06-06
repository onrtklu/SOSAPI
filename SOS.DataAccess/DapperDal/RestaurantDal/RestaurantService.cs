using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.RestaurantDal
{
    public class RestaurantService : DapperGenericRepository<Restaurant>, IRestaurantService
    {
        public RestaurantService(IDbTransaction transaction) : base(transaction) { }
    }
}
