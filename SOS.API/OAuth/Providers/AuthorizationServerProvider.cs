using Microsoft.Owin.Security.OAuth;
using SOS.Business.Account;
using SOS.Business.DependencyResolvers.Ninject;
using SOS.Business.Manager.Customer;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SOS.API.OAuth.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private ICustomerManager _customerManager;
        public AuthorizationServerProvider()
        {
            _customerManager = InstanceFactory.GetInstance<ICustomerManager>();
        }
        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            var token = context.AccessToken;
            return base.TokenEndpointResponse(context);
        }

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var item = new DataObjects.ComplexTypes.Customer.LoginDto()
            {
                Email = context.UserName,
                Password = context.Password
            };

            var loginControl = _customerManager.LoginCustomer(item);
            
            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.
            if (loginControl.Statu)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                identity.AddClaim(new Claim("userid", ((SosOpResult)loginControl).Id.ToString()));
                //identity.AddClaim(new Claim("scope", context.Scope.FirstOrDefault()));

                context.Validated(identity);
            }
            else
            {
                context.SetError(loginControl.Status, loginControl.Message);
            }
        }
    }
}