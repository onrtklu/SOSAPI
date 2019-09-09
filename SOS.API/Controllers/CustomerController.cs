using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
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

        [HttpGet]
        [Route("login", Name = "Login")]
        [SwaggerResponse(HttpStatusCode.OK, "Login customer", typeof(SosResult<ResultRegisterLoginDto>))]
        public IHttpActionResult Login(string Email, string Password)
        {
            LoginDto loginDto = new LoginDto()
            {
                Email = Email,
                Password = Password
            };

            var item = _customerManager.Login(loginDto);
            return response(item);
        }

        [HttpPost]
        [Route("register", Name = "Register")]
        [SwaggerResponse(HttpStatusCode.OK, "Register customer", typeof(SosOpDataResult<ResultRegisterLoginDto>))]
        public IHttpActionResult Register([FromBody]RegisterDto registerDto)
        {
            var item = _customerManager.RegisterCustomer(registerDto);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("GetCustomer", null),
                Rel = "get-customer",
                method = "GET"
            });

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

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("Update", null),
                Rel = "update-customer",
                method = "PUT"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("ChangePassword", null),
                Rel = "change-password",
                method = "PUT"
            });

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

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("GetCustomer", null),
                Rel = "get-customer",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("ChangePassword", null),
                Rel = "change-password",
                method = "PUT"
            });

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

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("GetCustomer", null),
                Rel = "get-customer",
                method = "PUT"
            });

            return response(item);
        }

    }
}
