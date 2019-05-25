using SOS.Core.DataAccess;
using SOS.DataAccess.UOW;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.EventDal
{
    public interface IEventService : IGenericRepository<Event>
    {
        List<Event> GetEventList();
        Event GetEvent(int id);
        List<EventDetailDto> GetEventDetailList();
    }
}
