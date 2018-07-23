using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask.ServiceProvider.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
