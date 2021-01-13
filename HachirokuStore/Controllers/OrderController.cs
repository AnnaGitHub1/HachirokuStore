using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HachirokuStore.Models.Invoice;
using HachirokuStore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HachirokuStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/Order
        /// <summary>
        /// Оформление заказа
        /// </summary>
        /// <param name="order"></param>
        [HttpPost]
        public async Task<string> Create([FromBody] OrderInfo order) => await _orderService.CreateShipment(HttpContext, order);
    }
}
