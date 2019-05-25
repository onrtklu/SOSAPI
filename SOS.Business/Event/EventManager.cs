using SOS.Business.Utilities.Response;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.UOW;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Event
{
    public class EventManager : IEventManager
    {
        private IUnitOfWork _uow;
        public EventManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ISosResult GetEvent(int id)
        {
            return Response.SosResult(_uow.EventService.GetEvent(id), HttpStatusCode.OK);
        }

        public ISosResult GetEventDetails()
        {
            //uow.EventService.insert();
            //_uow.Commit();
            return Response.SosResult(_uow.EventService.GetEventList(),HttpStatusCode.OK);
        }

        public ISosResult GetEventDetailList()
        {
            //DataObjects.Entities.Event @event = new DataObjects.Entities.Event()
            //{
            //    EventDate = DateTime.Now,
            //    HallID = 1,
            //    PlayID = 1
            //};

            //int newID = _uow.EventService.Add(@event);

            //_uow.Commit();

            //_uow.EventService.Add(@event);

            //_uow.Commit();
            //throw new DivideByZeroException();
           // return Response.SosError(HttpStatusCode.Unauthorized, "message");
            return Response.SosResult(_uow.EventService.GetEventDetailList(), HttpStatusCode.OK, "nullable message");
        }
    }
}
