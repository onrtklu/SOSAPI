using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
