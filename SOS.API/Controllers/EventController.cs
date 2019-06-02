using SOS.Business.Manager.Event;
using SOS.Business.Utilities.Response;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.Entities;
using SOS.DataObjects.HateoasType;
using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SOS.API.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : BaseController
    {
        private readonly IEventManager _eventManager;
        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        // GET: api/Event
        [Route("get-all", Name = "GetAll")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "get event list", Type = typeof(SosResult<IEnumerable<Event>>))]
        public IHttpActionResult Get()
        {
            return response(_eventManager.GetEvent());
        }

        // GET: api/Event/5
        [Route("", Name = "GetById")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "get a event", Type = typeof(SosResult<IEnumerable<Event>>))]
        public IHttpActionResult Get(int id)
        {
            var item = _eventManager.GetEvent(id);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("GetAll", null),
                Rel = "get-all-event",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("GetPredicate", null),
                Rel = "get-predicate",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("GetById", new { id }),
                Rel = "self",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("PutEvent", new { id }),
                Rel = "post-event",
                method = "PUT"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("PutEvent", new { id }),
                Rel = "put-event",
                method = "PUT"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("DeleteEvent", new { id }),
                Rel = "delete-event",
                method = "DELETE"
            });

            return response(item);

            //return response(_eventManager.GetEvent(id));
        }
        
        [Route("predicate", Name = "GetPredicate")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "get a event", Type = typeof(SosResult<IEnumerable<Event>>))]
        public IHttpActionResult GetPredicate()
        {
            var item = _eventManager.GetEventPredicate();

            return response(item);
        }

        [Route("detail", Name = "GetDetail")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "get details of events", Type = typeof(SosResult<IEnumerable<EventDetailDto>>))]
        public IHttpActionResult GetDetailList()
        {
            //var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Oops!!!" };
            //throw new HttpResponseException(msg);

            //return _eventManager.GetEventDetailList();


            return response(_eventManager.GetEventDetailList());
            ////return new ResponseMessageResult( Request.CreateResponse(HttpStatusCode.BadRequest, _eventManager.GetEventDetailList()));
            //// throw new DivideByZeroException();
            //return InternalServerError(new DivideByZeroException());
            ////    throw new UnauthorizedAccessException();
            //// return BadRequest();
            //return Ok(_eventManager.GetEventDetailList());
        }


        // POST: api/Event
        [Route("", Name = "PostEvent")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "insert a event", Type = typeof(SosOpResult))]
        public IHttpActionResult Post([FromBody]EventInsertDto value)
        {
            return response(_eventManager.InsertEvent(value));
        }

        // PUT: api/Event/5
        [Route("", Name = "PutEvent")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "update a event", Type = typeof(SosOpResult))]
        public IHttpActionResult Put(int id, [FromBody]Event value)
        {
            return response(_eventManager.UpdateEvent(value));
        }

        // DELETE: api/Event/5
        [Route("", Name = "DeleteEvent")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "delete a event", Type = typeof(SosOpResult))]
        public IHttpActionResult Delete(int id)
        {
            return response(_eventManager.DeleteEvent(id));
        }


    }
}
