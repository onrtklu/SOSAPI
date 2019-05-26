using SOS.Core.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Dal
{
    public interface IDalSession : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
