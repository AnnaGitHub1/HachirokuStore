using HachirokuStore.Models.Goods;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HachirokuStore.Data.Models
{
    /// <summary>
    /// Продукт в корзине
    /// </summary>
    public class CartItem
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Id корзины
        /// </summary>
        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public GoodSummary Good { get; set; }
    }
}
