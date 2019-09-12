using Newtonsoft.Json;
using RestSharp;
using SOS.DataObjects.ComplexTypes.Customer;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SOS.Business.Utilities.UrlUtilities.RestSharp
{
    public static class TokenUtility
    {
        public static AuthToken GetTokenUtility(string Email, string Password)
        {

            var client = new RestClient(BaseUrlUtility.GetBaseUrl() + "api/token");
            var request = new RestRequest(Method.POST);

            request.Parameters.Clear();
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", Email);
            request.AddParameter("password", Password);
            request.AddParameter("scope", "1"); //Get Token From Login

            IRestResponse response = client.Execute<AuthToken>(request);

            return JsonConvert.DeserializeObject<AuthToken>(response.Content);
        }

        public static AuthToken GetTokenUtilityFromRefreshToken(string RefreshToken, string Email)
        {

            var client = new RestClient(BaseUrlUtility.GetBaseUrl() + "api/token");
            var request = new RestRequest(Method.POST);

            request.Parameters.Clear();
            request.AddParameter("grant_type", "password");
            request.AddParameter("refresh_token", RefreshToken);
            request.AddParameter("username", Email);
            request.AddParameter("scope", "2"); //Get Refresh Token From 

            IRestResponse response = client.Execute<AuthToken>(request);

            return JsonConvert.DeserializeObject<AuthToken>(response.Content);
        }


        public static SosResult<CustomerDto> GetUserInfo(string token)
        {

            var client = new RestClient(BaseUrlUtility.GetBaseUrl() + "api/customer");
            var request = new RestRequest(Method.GET);

            request.Parameters.Clear();
            request.AddHeader("Authorization", "Bearer " + token);

            IRestResponse response = client.Execute<SosResult<CustomerDto>>(request);

            return JsonConvert.DeserializeObject<SosResult<CustomerDto>>(response.Content);
        }

    }
}
