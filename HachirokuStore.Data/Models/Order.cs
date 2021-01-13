using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HachirokuStore.Data.Models
{
    public class Order
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        [MaxLength(1500)]
        public string Comment { get; set; }

        public string CartId { get; set; }
    }
}
