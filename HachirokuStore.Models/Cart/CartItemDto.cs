using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Models.Cart
{
    /// <summary>
    /// Список товаров в корзине
    /// </summary>
    public class CartItemDto
    {
        public string GoodId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public string PathToTitulPhoto { get; set; }
    }
}
