using SOS.Core.DataAccess;
using SOS.DataObjects.Entities.CustomerSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.CustomerDal
{
    public interface ICustomerService : IGenericRepository<Customers>
    {
    }
}
