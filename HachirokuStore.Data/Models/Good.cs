using HachirokuStore.Models.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HachirokuStore.Data.Models
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Good
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// В наличии
        /// </summary>
        public bool IsInStock { get; set; }

        public string Colour { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public GoodCategory GoodCategory { get; set; }

        public string[] PathsToPhotos { get; set; }
    }
}
