using AutoMapper;
using HachirokuStore.Data.Context;
using HachirokuStore.Data.Models;
using HachirokuStore.Models.Configuration;
using HachirokuStore.Models.Invoice;
using HachirokuStore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HachirokuStore.Service
{
    public class OrderService : IOrderService
    {
        private readonly HachirokuContext hachirokuContext;
        private readonly IMapper _mapper;
        private readonly ICartService cartService;

        public OrderService(IOptions<MongoSettings> mongoSettings, IMapper mapper)
        {
            hachirokuContext = new HachirokuContext(mongoSettings);
            _mapper = mapper;

            cartService = new CartService(mongoSettings, mapper);
        }

        public async Task<string> CreateShipment(HttpContext context, OrderInfo newOrder)
        {
            var order = _mapper.Map<OrderInfo, Order>(newOrder);

            await hachirokuContext.Orders.InsertOneAsync(order);

            cartService.DeleteCookieCart(context, newOrder.CartId);

            return order.Id;
        }
    }
}
