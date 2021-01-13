using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HachirokuStore.Models.Goods
{
    /// <summary>
    /// Краткая информация о товаре
    /// </summary>
    public class GoodSummary
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }

        public string PathToTitulPhoto { get; set; }
    }
}
