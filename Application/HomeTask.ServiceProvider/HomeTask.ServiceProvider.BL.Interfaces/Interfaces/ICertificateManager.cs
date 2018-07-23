using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask.ServiceProvider.BL.Interfaces.Interfaces
{
    public interface ICertificateManager
    {
        SecurityKey ObtainSecurityKey(string filePath);
    }
}
