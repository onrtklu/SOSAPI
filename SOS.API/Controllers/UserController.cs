using SOS.API.Service;
using SOS.DataObjects.Entities;
using SOS.DataObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOS.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("api/User/AuthTest")]
        public SosResult<IEnumerable<KeyValuePair<string,string>>> AuthTest()
        {
            var identity = User.Identity as System.Security.Claims.ClaimsIdentity;

            //var result = identity.Claims.Select(c => new
            //{
            //    Type = c.Type,
            //    Value = c.Value
            //});

            var sosResult = identity.Claims.Select(
                s => new KeyValuePair<string, string>(s.Type, s.Value)
            );

            SosResult<IEnumerable<KeyValuePair<string, string>>> r = new SosResult<IEnumerable<KeyValuePair<string, string>>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = sosResult
            };

            return r;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return _userService.GetUserFullNames();
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
