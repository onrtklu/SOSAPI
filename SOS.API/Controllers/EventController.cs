using SOS.Business.Event;
using SOS.Business.Utilities.Response;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.Entities;
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
        [SwaggerResponse(HttpStatusCode.OK,Description ="get event list", Type= typeof(SosResult<IEnumerable<Event>>))]
        public IHttpActionResult Get()
        {
            return response(_eventManager.GetEvent());
        }

        // GET: api/Event/5
        [SwaggerResponse(HttpStatusCode.OK,Description ="get a event", Type= typeof(SosResult<IEnumerable<EventDetailDto>>))]
        public IHttpActionResult Get(int id)
        {
            return response(_eventManager.GetEvent(id));
        }

        [Route("detail")]
        [SwaggerResponse(HttpStatusCode.OK,Description ="get details of events", Type= typeof(SosResult<IEnumerable<EventDetailDto>>))]
        public IHttpActionResult GetDetailList()
        {
            //var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Oops!!!" };
            //throw new HttpResponseException(msg);

            //return _eventManager.GetEventDetailList();
            return response(_eventManager.GetEventDetailList());
            //return new ResponseMessageResult( Request.CreateResponse(HttpStatusCode.BadRequest, _eventManager.GetEventDetailList()));
           // throw new DivideByZeroException();
            return InternalServerError(new DivideByZeroException());
            //    throw new UnauthorizedAccessException();
           // return BadRequest();
            return Ok(_eventManager.GetEventDetailList());
        }


        // POST: api/Event
        [SwaggerResponse(HttpStatusCode.OK,Description ="insert a event", Type= typeof(SosOpResult))]
        public IHttpActionResult Post([FromBody]Event value)
        {
            return response(Response.sosOpResult(HttpStatusCode.Created, 1, "mes"));
        }

        // PUT: api/Event/5
        [SwaggerResponse(HttpStatusCode.OK,Description ="update a event", Type= typeof(SosOpResult))]
        public IHttpActionResult Put(int id, [FromBody]Event value)
        {
            return response(Response.sosOpResult(HttpStatusCode.Forbidden, 1, "dont"));
        }

        // DELETE: api/Event/5
        [SwaggerResponse(HttpStatusCode.OK,Description ="delete a event", Type= typeof(SosOpResult))]
        public IHttpActionResult Delete(int id)
        {
            return response(Response.sosOpResult(HttpStatusCode.Accepted, 1, "dont"));
        }


    }
}
