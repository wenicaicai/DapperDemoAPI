using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComplexClassToUseMapper;
using DapperDemoAPI.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private IOrderService _orderService { get; set; }
        // GET: api/Customer
        [Route("Order")]
        [HttpGet]
        public Order Get()
        {
            var result = _orderService.GenOrder();
            return result;
        }

        [Route("OrderDto")]
        [HttpGet]
        public OrderDto OrderDto()
        {
            var result = _orderService.GenOrderI();
            return result;
        }
    }
}