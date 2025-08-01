using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using MahalaxmiAPI.Models;
using MahalaxmiAPI.Models.DataModels;

namespace MahalaxmiAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            mahachem_mahalaxmichemicaContext newContext = new mahachem_mahalaxmichemicaContext();
            var userDetails = newContext.UserProfileDetails.Where(t => t.UserId == user.Id && t.IsDeleted == false).FirstOrDefault();

            if (userDetails == null || userDetails.IsDeleted == null || userDetails.IsDeleted.Value != false)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var userCompany = newContext.UserCustomerMappingViews.Where(t => t.UserId == user.Id).ToList();

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user, userDetails, userCompany);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(ApplicationUser user, UserProfileDetail userDetails, List<UserCustomerMappingView> userCompany)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", user.UserName },
                {"name",userDetails.Name },
                {"userId",user.Id },
                {"userProfileId",userDetails.Id.ToString() },
                {"soldToPartyId", userCompany.Count == 1 ? userCompany[0].SoldToPartyId.ToString() :"0"  },
                {"soldToPartyName", userCompany.Count == 1 ? userCompany[0].CustomerName :""  }
                //{ "userName", "jpanchal" },
                //{"name","Jaimin Panchal" },
                //{"userId","asdfasdffasd" },
                //{"userProfileId","1" },
            };
            return new AuthenticationProperties(data);
        }
    }
}