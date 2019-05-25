using SOS.Business.DependencyResolvers.Ninject;
using SOS.Business.Utilities.Response;
using SOS.Core.Uow;
using SOS.DataAccess.Dal;
using SOS.DataAccess.DapperDal.EventDal;
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
        private IEventService _eventService;

        public ISosResult GetEvent(int id)
        {
            using (DalSession dalSession = new DalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                return Response.SosResult(_eventService.GetEvent(id), HttpStatusCode.OK);
            }
        }

        public ISosResult GetEvent()
        {
            using (DalSession dalSession = new DalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                return Response.SosResult(_eventService.GetEventList(), HttpStatusCode.OK);
            }
        }

        public ISosResult GetEventDetailList()
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork unitOfWork = dalSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    _eventService = InstanceFactory.GetService<IEventService>(unitOfWork);
                    //_eventService.Insert(myPoco);

                    unitOfWork.Commit();

                    return Response.SosResult(_eventService.GetEventDetailList(), HttpStatusCode.OK);
                }
                catch
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

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
            //return Response.SosResult(_uow.EventService.GetEventDetailList(), HttpStatusCode.OK, "nullable message");
        }
    }
}
