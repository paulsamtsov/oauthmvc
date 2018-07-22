using HomeTask.ServiceProvider.BL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.BusinessManagers
{
    public class WorkspaceAuthenticationManager : IBaseAuthenticationManager
    {
        private readonly ICertificateManager _certManager;

        public WorkspaceAuthenticationManager(ICertificateManager certificateManager)
        {
            _certManager = certificateManager ?? throw new ArgumentNullException("Certification manger not supplied");
        }

        public string CreateAuthenticationUrl(string authentictionUrl, string clientId, string scope, string redirectUrl)
        {
            return string.Format(authentictionUrl, clientId, scope, redirectUrl, "token");
        }

        public void SignOut()
        {
            throw new NotImplementedException();
        }

        public IPrincipal ValidateAuthenticationToken(string token, string filePath)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
                    {
                        AuthenticationType = "ExternalCookie",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = _certManager.ObtainSecurityKey(filePath),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };

            SecurityToken validatedToken;
            var ClaimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            
            return tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        }
    }
}
