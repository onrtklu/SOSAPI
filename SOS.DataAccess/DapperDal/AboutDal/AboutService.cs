using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.SosSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.AboutDal
{
    public class AboutService : DapperGenericRepository<About>, IAboutService
    {
        public AboutService(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
