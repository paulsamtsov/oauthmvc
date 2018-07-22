using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.Interfaces
{
    public interface IBaseAuthenticationManager
    {
        string CreateAuthenticationUrl(string authentictionUrl, string clientId, string scope, string redirectUrl);
        IPrincipal ValidateAuthenticationToken(string token, string filePath);
        void SignOut();
    }
}
