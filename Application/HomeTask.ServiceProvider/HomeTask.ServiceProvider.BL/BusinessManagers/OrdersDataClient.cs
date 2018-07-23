using HomeTask.ServiceProvider.BL.Interfaces;
using HomeTask.ServiceProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask.ServiceProvider.BL.BusinessManagers
{
    public class OrdersDataClient : BaseRestClient, IOrdersDataClient
    {
        private const string _ordersEndpoint = "/api/Orders/";
        private readonly string _baseUrl;

        public OrdersDataClient(string accessToken, string url)
            : base(accessToken)
        {
            this._baseUrl = url;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var response = await GetAsync(_baseUrl + _ordersEndpoint);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<IEnumerable<Order>>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("Failed to retrieve orders information");
        }
    }
}
