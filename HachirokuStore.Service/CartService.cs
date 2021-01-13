using HachirokuStore.Data.Context;
using HachirokuStore.Models.Configuration;
using HachirokuStore.Service.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Linq;
using HachirokuStore.Data.Models;
using System.Collections.Generic;
using HachirokuStore.Models.Cart;
using HachirokuStore.Models.Goods;
using AutoMapper;

namespace HachirokuStore.Service
{
    public class CartService : ICartService
    {
        private readonly HachirokuContext hachirokuContext;
        private readonly IMapper _mapper;

        private const string CookieKey = "CartId";

        public CartService(IOptions<MongoSettings> mongoSettings, IMapper mapper)
        {
            hachirokuContext = new HachirokuContext(mongoSettings);
            _mapper = mapper;
        }

        public async Task<bool> AddCartItem(HttpContext context, GoodSummary good, int? quantity)
        {
            try
            {
                var shoppingCartId = GetCartId(context);

                var cursor = await hachirokuContext.CartItems
                    .FindAsync(f => f.CartId == shoppingCartId && f.Good.Id == good.Id);

                var cartItem = cursor.ToEnumerable().FirstOrDefault();

                if (cartItem != null)
                {
                    var filter = Builders<CartItem>.Filter.Eq(e => e.Id, cartItem.Id);

                    var update = Builders<CartItem>.Update
                        .Set(p => p.Quantity, quantity ?? ++cartItem.Quantity);

                    await hachirokuContext.CartItems.UpdateOneAsync(filter, update);
                }

                else
                {
                    cartItem = new CartItem
                    {
                        CartId = shoppingCartId,
                        DateCreated = DateTime.Now,
                        Quantity = 1,
                        Good = good
                    };

                    await hachirokuContext.CartItems.InsertOneAsync(cartItem);
                }

                return cartItem.Id != null;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveGoods(string cartId, string goodId = null)
        {
            try
            {
                var filter = goodId == null
                    ? Builders<CartItem>.Filter.Eq(e => e.CartId, cartId)
                    : Builders<CartItem>.Filter.Eq(e => e.CartId, cartId) & Builders<CartItem>.Filter.Eq(e => e.Good.Id, goodId);

                await hachirokuContext.CartItems.DeleteManyAsync(filter);

                return true;
            }

            catch(Exception)
            {
                return false;
            }
        }

        public async Task<List<CartItemDto>> GetCartItemsList(string cartId)
        {
            var cursor = await hachirokuContext.CartItems
                    .FindAsync(f => f.CartId == cartId);

            var cartItems = cursor.ToEnumerable();
           
            return _mapper.Map<IEnumerable<CartItem>, List<CartItemDto>>(cartItems);            
        }

        public void DeleteCookieCart(HttpContext context, string cartId)
        {
            if (context.Request.Cookies.ContainsKey(CookieKey))
            {
                context.Response.Cookies.Delete(CookieKey);
            }
        }

        /// <summary>
        /// Возвращает Id корзины
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCartId(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(CookieKey))
            {
                var IsGet = context.Request.Cookies.TryGetValue(CookieKey, out string cartId);

                return IsGet ? cartId : null;
            }
                var tempCartId = Guid.NewGuid().ToString();
                context.Response.Cookies.Append(CookieKey, tempCartId);

            return tempCartId;
        }
    }
}
