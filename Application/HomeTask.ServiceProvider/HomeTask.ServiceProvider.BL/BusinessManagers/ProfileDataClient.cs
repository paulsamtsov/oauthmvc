using HomeTask.ServiceProvider.BL.Interfaces.Interfaces;
using HomeTask.ServiceProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.BusinessManagers
{
    public class ProfileDataClient : BaseRestClient, IProfileDataClient
    {
        private readonly string _baseUrl;

        public ProfileDataClient(string accessToken, string url)
            : base(accessToken)
        {
            this._baseUrl = url;
        }

        public async Task<ProfileData> GetProfileDataAsync()
        {
            var response = await this.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ProfileData>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("Failed to retrieve profile information");
        }
    }
}
