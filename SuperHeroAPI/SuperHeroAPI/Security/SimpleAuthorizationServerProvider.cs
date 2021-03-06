﻿using Microsoft.Owin.Security.OAuth;
using SuperHeroAPI.EntityFramework;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperHeroAPI
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUsersServices UsersServices;
        private  SuperHeroAPIContext _context;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext contextOAuth)
        {
            contextOAuth.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext contextOAuth)
        {

            _context = new SuperHeroAPIContext();
            UsersServices = new UsersServices(_context);

            contextOAuth.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });


            var user = UsersServices.Authenticate(contextOAuth.UserName, contextOAuth.Password);

            if (user == null)
            {
                contextOAuth.SetError("invalid_grant", "O username e/ou o password são inválidos.");
                return;
            }

            var role = user.Roles.Select(x => x.Name).First();
         
            var identity = new ClaimsIdentity(contextOAuth.Options.AuthenticationType);
           identity.AddClaim(new Claim(ClaimTypes.Name, contextOAuth.UserName));
           identity.AddClaim(new Claim(ClaimTypes.Email, user.Password));
           identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
           identity.AddClaim(new Claim(ClaimTypes.Role, role));
           
            contextOAuth.Validated(identity);
        }
    }
}