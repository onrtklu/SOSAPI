using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace SOS.API.ExcHand
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var r = context.Request.CreateResponse( 
                HttpStatusCode.OK,
                new SosErrorResult
                {
                    Statu = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = context.Exception.Message
                }
            );
            context.Result = new ResponseMessageResult(r);
        }
        

    }
}