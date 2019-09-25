using SOS.Business.Manager.About;
using SOS.Business.Manager.Contact;
using SOS.DataObjects.ComplexTypes.About;
using SOS.DataObjects.ComplexTypes.Contact;
using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOS.API.Controllers
{
    [RoutePrefix("api/about")]
    public class AboutController : BaseController
    {
        private IAboutManager _aboutManager;
        private IContactManager _contactManager;
        public AboutController(IAboutManager aboutManager, IContactManager contactManager)
        {
            _aboutManager = aboutManager;
            _contactManager = contactManager;
        }

        [HttpGet]
        [Route("", Name = "GetAbout")]
        [SwaggerResponse(HttpStatusCode.OK, "Get about", typeof(SosResult<AboutDto>))]
        public IHttpActionResult GetAbout()
        {
            var item = _aboutManager.GetAbout();

            return Ok(item);
        }

        [HttpPost]
        [Route("send-message", Name = "SendMessage")]
        [SwaggerResponse(HttpStatusCode.OK, "Send Message", typeof(SosResult<SosOpResult>))]
        public IHttpActionResult SendMessage([FromBody]ContactDtoInsert contactDtoInsert)
        {
            var item = _contactManager.SendMessage(contactDtoInsert);

            return Ok(item);
        }
    }
}
