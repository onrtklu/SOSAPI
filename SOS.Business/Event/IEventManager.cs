using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Event
{
    public interface IEventManager
    {
        ISosResult GetEvent();
        ISosResult GetEvent(int id);
        ISosResult GetEventDetailList();
    }
}
