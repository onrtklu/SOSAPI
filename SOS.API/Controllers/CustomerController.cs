using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SOS.API.ExcHand;
using SOS.Business.Manager.Customer;
using SOS.DataObjects.ComplexTypes.Customer;
using SOS.DataObjects.HateoasType;
using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http;

namespace SOS.API.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : BaseController
    {
        private ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }


        [HttpPost]
        [Route("register", Name = "Register")]
        [SwaggerResponse(HttpStatusCode.OK, "Register customer", typeof(SosResult<SosOpResult>))]
        public IHttpActionResult Register([FromBody]RegisterDto registerDto)
        {
            var item = _customerManager.RegisterCustomer(registerDto);

            return response(item);
        }

        [HttpPut]
        [SosAuthorize]
        [Route("", Name = "Update")]
        [SwaggerResponse(HttpStatusCode.OK, "Update customer", typeof(SosResult<SosOpResult>))]
        public IHttpActionResult UpdateCustomer([FromBody]UpdateCustomerDto updateCustomerDto)
        {
            int customer_Id = GetUserId();

            var item = _customerManager.UpdateCustomer(customer_Id ,updateCustomerDto);

            return response(item);
        }

        [HttpPut]
        [SosAuthorize]
        [Route("change-password", Name = "ChangePassword")]
        [SwaggerResponse(HttpStatusCode.OK, "Change Password", typeof(SosResult<SosOpResult>))]
        public IHttpActionResult ChangePassword([FromBody]ChangePasswordDto changePasswordDto)
        {
            int customer_Id = GetUserId();

            var item = _customerManager.ChangePassword(customer_Id, changePasswordDto);

            return response(item);
        }

        [HttpGet]
        [SosAuthorize]
        [Route("", Name = "GetCustomer")]
        [SwaggerResponse(HttpStatusCode.OK, "Get customer", typeof(SosResult<CustomerDto>))]
        public IHttpActionResult GetCustomer()
        {
            int customer_Id = GetUserId();

            var item = _customerManager.GetCustomer(customer_Id);

            return response(item);
        }
    }
}
