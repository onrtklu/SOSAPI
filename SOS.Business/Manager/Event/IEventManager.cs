using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Event
{
    public interface IEventManager
    {
        ISosResult GetEvent();
        ISosResult GetEvent(int id);
        ISosResult GetEventPredicate();
        ISosResult GetEventDetailList();
        ISosResult InsertEvent(DataObjects.ComplexTypes.Event.EventInsertDto @event);
        ISosResult UpdateEvent(DataObjects.Entities.Event @event);
        ISosResult DeleteEvent(int id);
    }
}
