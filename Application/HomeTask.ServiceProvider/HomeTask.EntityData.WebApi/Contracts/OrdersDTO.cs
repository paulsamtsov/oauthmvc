using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTask.EntityData.WebApi.Contracts
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
