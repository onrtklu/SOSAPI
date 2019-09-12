using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
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
            if (context.TokenIssued)
            {
                // client information
                var accessExpiration = DateTimeOffset.Now.AddSeconds(10);
                context.Properties.ExpiresUtc = accessExpiration;
            }
            return Task.FromResult<object>(null);
            
            //var token = context.AccessToken;
            //return base.TokenEndpointResponse(context);
        }

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // CORS ayarlarını set ediyoruz.
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var tokenType = context.Scope.FirstOrDefault();

            if (tokenType == "1") //Get Token From Login
                GetTokenFromLogin(context);
            else if (tokenType == "2") //Get Refresh Token From Login
                GetRefreshTokenFromLogin(context);
            else if (tokenType == "3") //Get Token From Refresh Token
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

                AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120),
                    AllowRefresh = true,
                    IsPersistent = true
                };

                AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, authenticationProperties);


                context.Validated(authenticationTicket);
            }
            else
            {
                context.SetError(loginControl.Status, loginControl.Message);
            }
        }

        private void GetRefreshTokenFromLogin(OAuthGrantResourceOwnerCredentialsContext context)
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

                AuthenticationProperties authenticationProperties = new AuthenticationProperties()
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(500),
                    AllowRefresh = true,
                    IsPersistent = true
                };

                AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, authenticationProperties);

                context.Validated(authenticationTicket);
            }
            else
            {
                context.SetError(loginControl.Status, loginControl.Message);
            }
        }

        private void GetTokenFromRefreshToken(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim("userid", context.ClientId));
            //identity.AddClaim(new Claim("scope", context.Scope.FirstOrDefault()));

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            AuthenticationTicket authenticationTicket = new AuthenticationTicket(identity, authenticationProperties);


            context.Validated(authenticationTicket);
        }
    }
}