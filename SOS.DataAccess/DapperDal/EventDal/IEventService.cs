using SOS.DataAccess.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.EventDal
{
    public interface IEventService
    {
        IList<string> GetEventDetails();
        string GetEvent(int id);
    }
}
