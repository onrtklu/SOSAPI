using Microsoft.Owin.Security.OAuth;
using SOS.Business.DependencyResolvers.Ninject;
using SOS.Business.Manager.Customer;
using SOS.DataObjects.Entities.CustomerSchema;
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

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var tokenType = context.Scope.FirstOrDefault();

            if (tokenType == "1" || tokenType == "") //Get Token From Login
                GetTokenFromLogin(context);
            else if (tokenType == "2") //Get Token From Refresh Token
                GetTokenFromRefreshToken(context);
        }

        private void GetTokenFromLogin(OAuthGrantResourceOwnerCredentialsContext context)
        {

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

        private void GetTokenFromRefreshToken(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var customer = _customerManager.GetUserByRefreshToken(context.UserName);

            if (customer.Statu)
            {

                identity.AddClaim(new Claim("sub", ((SosOpDataResult<Customers>)customer).Data.Email.ToString()));
                identity.AddClaim(new Claim("role", "user"));
                identity.AddClaim(new Claim("userid", ((SosOpDataResult<Customers>)customer).Id.ToString()));
                //identity.AddClaim(new Claim("userid", context.ClientId));
                //identity.AddClaim(new Claim("scope", context.Scope.FirstOrDefault()));

                context.Validated(identity);
            }
            else
            {
                context.SetError(customer.Status, customer.Message);
            }
        }
    }
}