using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.CustomerSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.CustomerDal
{
    public class CustomerService : DapperGenericRepository<Customers>, ICustomerService
    {
        public CustomerService(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
