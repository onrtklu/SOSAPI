using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Event
{
    public interface IEventManager
    {
        IList<string> GetEventDetails();
        string GetEvent(int id);
    }
}
