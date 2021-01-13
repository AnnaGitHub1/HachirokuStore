using HachirokuStore.Models.Invoice;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HachirokuStore.Service.Interfaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="context"></param>
        /// <param name="newOrder"></param>
        /// <returns>номер заказа</returns>
        Task<string> CreateShipment(HttpContext context, OrderInfo newOrder);
    }
}
