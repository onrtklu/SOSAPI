using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace SOS.API.Controllers
{
    [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(SosErrorResult))]
    public class BaseController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public ResponseMessageResult response(ISosResult data)
        {
                return new ResponseMessageResult(Request.CreateResponse(data.StatusCode, data));
        }

    }
}
