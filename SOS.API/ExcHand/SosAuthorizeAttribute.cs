using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace SOS.API.ExcHand
{
    public class SosAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new SosErrorResult
                    {
                        Statu = false,
                        StatusCode = HttpStatusCode.Unauthorized,
                        Message = "Yetkisiz Kullanıcı"
                    });
                return Task.FromResult<object>(null);
            }

            if (!(principal.HasClaim(x => x.Type == "role")))
            {
                var customClaimValue = principal.Claims.Where(c => c.Type == "userid").SingleOrDefault();

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new SosErrorResult
                    {
                        Statu = false,
                        StatusCode = HttpStatusCode.Unauthorized,
                        Message = "Yetkisiz Kullanıcı"
                    });
                return Task.FromResult<object>(null);
            }

            //User is Authorized, complete execution
            return Task.FromResult<object>(null);
        }

      
    }

}