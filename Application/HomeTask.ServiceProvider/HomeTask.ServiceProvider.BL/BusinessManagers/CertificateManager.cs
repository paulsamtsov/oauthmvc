using HomeTask.ServiceProvider.BL.Interfaces.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
