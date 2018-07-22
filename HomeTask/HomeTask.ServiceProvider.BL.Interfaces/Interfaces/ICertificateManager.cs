using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.Interfaces
{
    public interface ICertificateManager
    {
        SecurityKey ObtainSecurityKey(string filePath);
    }
}
