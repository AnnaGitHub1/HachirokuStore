using HachirokuStore.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace HachirokuStore.Service.Helpers
{
    public static class SortHelper
    {
        public static void SortGoods(IEnumerable<Good> goodEnumerable, string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                var splitSort = sort.Split(" ");

                goodEnumerable = splitSort.LastOrDefault() == "asc"
                    ? goodEnumerable.OrderBy(o => o.GetType().GetProperty(splitSort.FirstOrDefault()))
                    : goodEnumerable.OrderByDescending(o => o.GetType().GetProperty(splitSort.FirstOrDefault()));
            }
        }
    }
}
