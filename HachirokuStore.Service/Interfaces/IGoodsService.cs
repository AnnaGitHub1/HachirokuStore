
using HachirokuStore.Models.Enums;
using HachirokuStore.Models.Goods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HachirokuStore.Service.Interfaces
{
    public interface IGoodsService
    {
        /// <summary>
        /// Возвращает краткую информацию обо всех товарах
        /// </summary>
        /// <returns></returns>
        Task<List<GoodSummary>> GetAllActiveGoods(int startIndex, int pageSize, string sort, GoodCategory? categoryFilter);

        /// <summary>
        /// Возвращает полную информацию о выбранном товаре
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GoodFullDescription> GetGoodFullDescription(string id);

        /// <summary>
        /// Возвращает фотогафию товара
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] FindPhoto(string path);
    }
}
