using HachirokuStore.Data.Models;
using HachirokuStore.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Data.Context
{
    public class HachirokuContext
    {
        private readonly IMongoDatabase _database = null;

        public HachirokuContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Good> Goods => _database.GetCollection<Good>("Goods");
        public IMongoCollection<CartItem> CartItems => _database.GetCollection<CartItem>("CartItems");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
