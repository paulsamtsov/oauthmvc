using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTask.EntityData.WebApi.Contracts;
using HomeTask.EntityData.WebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeTask.EntityData.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    [Authorize(Roles = "Matrix42.MyWorkspace.Customer")]
    public class OrdersController : Controller
    {
        private readonly IDataRepository _dataRepository;
        public OrdersController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IEnumerable<OrdersDTO> Get()
        {
            return _dataRepository.GetOrders();
        }
    }
}