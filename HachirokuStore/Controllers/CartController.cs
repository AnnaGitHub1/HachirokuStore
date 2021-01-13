using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HachirokuStore.Models.Cart;
using HachirokuStore.Models.Goods;
using HachirokuStore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HachirokuStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        //Get: api/Cart/1
        /// <summary>
        /// Получить список товаров в корзине
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet("{cartId}")]
        public async Task<List<CartItemDto>> CartItemsList(string cartId) => await _cartService.GetCartItemsList(cartId);

        // Post: api/Cart
        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="goodId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> AddGoodToCart([FromBody]GoodSummary good, int? quantity = null) => await _cartService.AddCartItem(HttpContext, good, quantity);

        /// <summary>
        /// Удаление товара\товаров из корзины
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="goodsId">если не указан удаляется вся корзина</param>
        /// <returns></returns>
        [HttpDelete("{cartId}")]
        public async Task<bool> DeleteGood(string cartId, string goodsId = null) => await _cartService.RemoveGoods(cartId, goodsId);
    }
}