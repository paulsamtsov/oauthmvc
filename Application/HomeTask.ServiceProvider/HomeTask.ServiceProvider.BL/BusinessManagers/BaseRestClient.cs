using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.BusinessManagers
{
    public class BaseRestClient
    {
        private readonly HttpClient _client;

        public BaseRestClient(string accessToken)
        {
            _client = new HttpClient();
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("Access token not specified");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return await _client.PostAsync(requestUri, content);
        }
    }
}
