using SOS.Business.DependencyResolvers.Ninject;
using SOS.Business.Utilities.Response;
using SOS.Core.Uow;
using SOS.DataAccess.Dal;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Event
{
    public class EventManager : BaseManager, IEventManager
    {
        private IEventService _eventService;

        public ISosResult GetEvent(int id)
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                var modEvent = _eventService.GetEvent(id);

                //if (modEvent == null)
                //    return HttpStatusCode.NoContent.SosErrorResult();

                return modEvent.SosResult();
            }
        }

        public ISosResult GetEvent()
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                return _eventService.GetEventList().SosResult();
            }
        }

        public ISosResult GetEventDetailList()
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                IUnitOfWork unitOfWork = dalSession.UnitOfWork;
                unitOfWork.Begin();
                try
                {
                    _eventService = InstanceFactory.GetService<IEventService>(unitOfWork);
                    //_eventService.Insert(myPoco);

                    unitOfWork.Commit();

                    return _eventService.GetEventDetailList().SosResult();
                }
                catch
                {
                    unitOfWork.Rollback();
                    return HttpStatusCode.BadRequest.SosErrorResult();
                    //return Response.SosError(HttpStatusCode.BadRequest);
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

        public ISosResult InsertEvent(DataObjects.Entities.Event @event)
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                if (@event == null)
                    return HttpStatusCode.NoContent.SosErrorResult();

                int scopeId = _eventService.Add(@event);
                return HttpStatusCode.Created.SosOpResult(scopeId);
            }
        }

        public ISosResult UpdateEvent(DataObjects.Entities.Event @event)
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                if (@event == null)
                    return HttpStatusCode.NoContent.SosErrorResult();

                bool result = _eventService.Update(@event);
                if (result)
                    return HttpStatusCode.OK.SosOpResult(@event.ID);
                else
                    return HttpStatusCode.BadRequest.SosErrorResult();
            }
        }

        public ISosResult DeleteEvent(int id)
        {
            using (IDalSession dalSession = InstanceDalSession())
            {
                _eventService = InstanceFactory.GetService<IEventService>(dalSession.UnitOfWork);

                var modEvent = _eventService.Get(id);

                if (modEvent == null)
                    //    return HttpStatusCode.NoContent.SosErrorResult();
                    return HttpStatusCode.OK.SosOpResult(id, "already no data");

                bool result = _eventService.Delete(modEvent);

                if (result)
                    return HttpStatusCode.OK.SosOpResult(id, "succeed");
                else
                    return HttpStatusCode.BadRequest.SosErrorResult();
            }
        }

    }
}
