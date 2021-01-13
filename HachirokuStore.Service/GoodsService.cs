using HachirokuStore.Data.Context;
using HachirokuStore.Models.Configuration;
using HachirokuStore.Models.Goods;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using HachirokuStore.Service.Interfaces;
using AutoMapper;
using HachirokuStore.Data.Models;
using HachirokuStore.Service.Helpers;
using HachirokuStore.Models.Enums;

namespace HachirokuStore.Service
{
    public class GoodsService : IGoodsService
    {
        private readonly HachirokuContext hachirokuContext;
        private readonly IMapper _mapper;

        public GoodsService(IOptions<MongoSettings> mongoSettings, IMapper mapper)
        {
            hachirokuContext = new HachirokuContext(mongoSettings);
            _mapper = mapper;
        }

        public async Task<List<GoodSummary>> GetAllActiveGoods(int startIndex, int pageSize, string sort, GoodCategory? categoryFilter)
        {
            var allGoods = categoryFilter == null
                ? await hachirokuContext.Goods.FindAsync(f => f.IsInStock)
                : await hachirokuContext.Goods.FindAsync(f => f.IsInStock && f.GoodCategory == categoryFilter);

            var allGoodsEnumerable = allGoods.ToEnumerable();

            SortHelper.SortGoods(allGoodsEnumerable, sort);

            return _mapper.Map<IEnumerable<Good>, List<GoodSummary>>(
                        Paginator.Paging(allGoodsEnumerable, startIndex, pageSize));
        }

        public async Task<GoodFullDescription> GetGoodFullDescription(string id)
        {
            var good = await hachirokuContext.Goods.FindAsync(f => f.Id == id);

            return _mapper.Map<Good, GoodFullDescription>(good.FirstOrDefault());
        }

        public byte[] FindPhoto(string path) => System.IO.File.ReadAllBytes(path);        
    }
}
