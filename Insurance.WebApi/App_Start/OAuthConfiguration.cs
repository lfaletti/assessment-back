﻿using System;
using System.Configuration;
using System.Web.Http;
using Insurance.Database;
using Insurance.IServices.Authentication;
using Insurance.Services.Authentication;
using Insurance.WebApi.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace Insurance.WebApi
{
    public static class OAuthConfiguration
    {
        public static void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

            app.CreatePerOwinContext(() => (InsuranceContext) GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(InsuranceContext)));
            app.CreatePerOwinContext(() => (AuthenticationService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(AuthenticationService)));

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            });

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[]
                {
                    new SymmetricKeyIssuerSecurityKeyProvider(issuer, secret)
                }
            });


        }
    }
}
