using SOS.Business.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOS.API.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventManager _eventManager;
        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }
               
        // GET: api/Event
        public IEnumerable<string> Get()
        {
            return _eventManager.GetEventDetails();
        }

        // GET: api/Event/5
        public string Get(int id)
        {
            return _eventManager.GetEvent(id);
        }

        // POST: api/Event
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
