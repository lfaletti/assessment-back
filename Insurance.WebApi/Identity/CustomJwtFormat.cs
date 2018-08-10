using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using SecurityAlgorithms = System.IdentityModel.Tokens.SecurityAlgorithms;

namespace Insurance.WebApi.Identity
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private static readonly byte[] _secret =
            TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["secret"]);

        private readonly string _issuer;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            //var signingKey = new HmacSigningCredentials(_secret);
            var signingKey = new SymmetricSecurityKey(_secret);
            var signingCredentials = new SigningCredentials(
                signingKey, SecurityAlgorithms.HmacSha256Signature);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_issuer, "Any", data.Identity.Claims,
                issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}