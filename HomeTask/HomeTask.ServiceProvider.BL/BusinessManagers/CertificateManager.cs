using HomeTask.ServiceProvider.BL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.BusinessManagers
{
    public class CertificateManager : ICertificateManager
    {
        public SecurityKey ObtainSecurityKey(string filePath)
        {
            return new X509SecurityKey(new X509Certificate2(filePath));

        }
    }
}
