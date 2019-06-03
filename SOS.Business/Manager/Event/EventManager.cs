using AutoMapper;
using FluentValidation.Results;
using SOS.Business.DependencyResolvers.Ninject;
using SOS.Business.Utilities.Response;
using SOS.Business.Utilities.Validation;
using SOS.Business.ValidationRules.FluentValidation;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.Uow;
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
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EventManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult GetEvent(int id)
        {
            var result = _uow.EventService.GetEvent(id);

            if (result == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            return result.SosResult();
        }

        public ISosResult GetEvent()
        {
            return _uow.EventService.GetAll().SosResult();
        }

        public ISosResult GetEventPredicate()
        {
            return _uow.EventService.Select(s=>s.PlayID == 1).SosResult();
        }

        public ISosResult GetEventDetailList()
        {
            return _uow.EventService.GetEventDetailList().SosResult();
        }

        public ISosResult InsertEvent(DataObjects.ComplexTypes.Event.EventInsertDto @event)
        {
            _uow.BeginTransaction();

            if (@event == null)
                return HttpStatusCode.NoContent.SosErrorResult();

            var mod = _mapper.Map<DataObjects.Entities.Event>(@event);

            Validate<EventValidatior, DataObjects.Entities.Event>.Valid(mod);
            
            object scopeId = _uow.EventService.Insert(mod);
            if (scopeId == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            _uow.Commit();

            return HttpStatusCode.Created.SosOpResult(Convert.ToInt32(scopeId));
        }

        public ISosResult UpdateEvent(DataObjects.Entities.Event @event)
        {
            if (@event == null)
                return HttpStatusCode.NoContent.SosErrorResult();

            bool result = _uow.EventService.Update(@event);
            if (result)
            {
                _uow.Commit();
                return HttpStatusCode.OK.SosOpResult(@event.Id);
            }
            else
                return HttpStatusCode.BadRequest.SosErrorResult();
        }

        public ISosResult DeleteEvent(int id)
        {
            var modEvent = _uow.EventService.Get(id);

            if (modEvent == null)
                //    return HttpStatusCode.NoContent.SosErrorResult();
                return HttpStatusCode.OK.SosOpResult(id, "already no data");

            bool result = _uow.EventService.Delete(modEvent);

            if (result)
            {
                _uow.Commit();
                return HttpStatusCode.OK.SosOpResult(id, "succeed");
            }
            else
                return HttpStatusCode.BadRequest.SosErrorResult();

        }

    }
}
