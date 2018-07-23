using HomeTask.ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.Interfaces.Interfaces
{
    public interface IProfileDataClient
    {
        Task<ProfileData> GetProfileDataAsync();
    }
}
