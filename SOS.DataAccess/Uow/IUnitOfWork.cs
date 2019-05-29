using SOS.DataAccess.DapperDal.EventDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IEventService EventService { get; }

        void Commit();
    }
}
