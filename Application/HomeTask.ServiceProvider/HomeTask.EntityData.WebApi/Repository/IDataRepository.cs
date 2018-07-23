using HomeTask.EntityData.WebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.EntityData.WebApi.Repository
{
    public interface IDataRepository
    {
        IEnumerable<OrdersDTO> GetOrders();
    }
}
