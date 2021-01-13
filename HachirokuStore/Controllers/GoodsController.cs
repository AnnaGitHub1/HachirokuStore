using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HachirokuStore.Models.Enums;
using HachirokuStore.Models.Goods;
using HachirokuStore.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HachirokuStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        // GET: api/Goods 
        /// <summary>
        /// Выводит список товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<GoodSummary>> Get(int startIndex = 0, int pageSize = 20, string sort = null, GoodCategory? categoryFilter = null) 
            => await _goodsService.GetAllActiveGoods(startIndex, pageSize, sort, categoryFilter);

        // GET: api/Goods/"5"
        /// <summary>
        /// Подробная информация о товаре
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<GoodFullDescription> Get(string id) => await _goodsService.GetGoodFullDescription(id);

        // GET: api/Goods/photo?path=C:\1\1.jpg
        [HttpGet]
        [Route("photo")]
        public IActionResult GetPhoto([FromQuery] string path)
        {
            var photo = _goodsService.FindPhoto(path);

            return File(photo, "image/jpeg");
        }
    }
}
