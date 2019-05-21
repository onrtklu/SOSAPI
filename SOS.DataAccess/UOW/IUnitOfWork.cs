using SOS.DataAccess.DapperDal.EventDal;
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
        IEventService EventService { get; }

        void Commit();
    }
}
