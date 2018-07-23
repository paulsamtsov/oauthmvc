using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HomeTask.ServiceProvider.Models;

namespace HomeTask.ServiceProvider.BL.Interfaces
{
    public interface IOrdersDataClient
    {
        Task<IEnumerable<Order>> GetOrders();
    }
}
