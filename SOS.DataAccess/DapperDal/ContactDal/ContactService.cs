using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.SosSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.ContactDal
{
    public class ContactService : DapperGenericRepository<Contact>, IContactService
    {
        public ContactService(IDbTransaction transaction) : base(transaction)
        {
        }
    }
}
