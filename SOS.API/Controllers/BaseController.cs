using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
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

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetQRCodeRestaurantId()
        {
            IEnumerable<string> qRCodeRestaurantId;
            bool validateQRCode = Request.Headers.TryGetValues("QRCodeRestaurantId", out qRCodeRestaurantId);

            if (!validateQRCode && qRCodeRestaurantId == null)
                throw new NullReferenceException("Restaurant Id is Required");

            return Convert.ToInt32(qRCodeRestaurantId.First());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetQRCodeTableId()
        {
            IEnumerable<string> qRCodeTableId;
            bool validateQRCode = Request.Headers.TryGetValues("QRCodeTableId", out qRCodeTableId);

            if (!validateQRCode && qRCodeTableId == null)
                throw new NullReferenceException("Table Id is Required");

            return Convert.ToInt32(qRCodeTableId.First());
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetClaim(string value)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var customClaimValue = principal.Claims.Where(c => c.Type == value).Single().Value;

            if (customClaimValue == null)
                throw new NullReferenceException(value + " bulunamadı");
            return customClaimValue;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int GetUserId()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var customClaimValue = principal.Claims.Where(c => c.Type == "userid").SingleOrDefault();

            if(customClaimValue == null || customClaimValue.Value == null)
                throw new NullReferenceException("Kullanıcı Id bulunamadı");

            return Convert.ToInt32(customClaimValue.Value);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
    }
}
