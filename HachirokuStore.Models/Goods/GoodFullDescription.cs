using HachirokuStore.Models.Enums;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Models.Goods
{
    public class GoodFullDescription
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Colour { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public string GoodCategory { get; set; }

        public string[] PathsToPhotos { get; set; }
    }
}
