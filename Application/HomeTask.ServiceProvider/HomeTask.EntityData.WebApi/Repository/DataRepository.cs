using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTask.EntityData.WebApi.Contracts;

namespace HomeTask.EntityData.WebApi.Repository
{
    public class DataRepository : IDataRepository
    {
        public IEnumerable<OrdersDTO> GetOrders()
        {
            return new List<OrdersDTO>
            {
                new OrdersDTO
                {
                    Id = 1,
                    Product = "Display",
                    Price = 129.99m,
                    Count = 3,
                    Customer = "Pavlo Samtsov"
                },
                new OrdersDTO
                {
                    Id = 2,
                    Product = "Desktop",
                    Price = 70.43m,
                    Count = 6,
                    Customer = "Ivan.Petrov"
                },
                new OrdersDTO
                {
                    Id = 3,
                    Product = "Mouse",
                    Price = 83.98m,
                    Count = 4,
                    Customer = "Petr.Ivanov"
                },
                new OrdersDTO
                {
                    Id = 4,
                    Product = "Keyboard",
                    Price = 199.99m,
                    Count = 3,
                    Customer = "Pavlo Samtsov"
                },
            };
        }
    }
}
