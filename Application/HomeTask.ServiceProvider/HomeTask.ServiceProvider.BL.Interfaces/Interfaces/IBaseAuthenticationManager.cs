using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace HomeTask.ServiceProvider.BL.Interfaces.Interfaces
{
    public interface IBaseAuthenticationManager
    {
        string CreateAuthenticationUrl(string authentictionUrl, string clientId, string scope, string redirectUrl);
        IPrincipal ValidateAuthenticationToken(string token, string filePath);
    }
}
