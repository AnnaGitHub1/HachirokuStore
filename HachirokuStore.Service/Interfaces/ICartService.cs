using HachirokuStore.Models.Cart;
using HachirokuStore.Models.Goods;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HachirokuStore.Service.Interfaces
{
    public interface ICartService
    {
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="context"></param>
        /// <param name="good"></param>
        /// <param name="quantity">число которое добавляют (если указано то перезаписывается текущее кол-во этим числом)</param>
        /// <returns>добавлен ли товар</returns>
        Task<bool> AddCartItem(HttpContext context, GoodSummary good, int? quantity);

        /// <summary>
        /// Получить список товаров в корзине
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<List<CartItemDto>> GetCartItemsList(string cartId);

        /// <summary>
        /// Удаление кук корзины для пользователя
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        void DeleteCookieCart(HttpContext context, string cartId);

        /// <summary>
        /// Удаление товара/товаров из корзины
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="goodId"></param>
        /// <returns></returns>
        Task<bool> RemoveGoods(string cartId, string goodId = null);
    }
}
