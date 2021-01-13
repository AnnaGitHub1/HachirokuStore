using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HachirokuStore.Service.Helpers
{
    public static class Paginator
    {
        public static IEnumerable<T> Paging<T>(IEnumerable<T> list, int startIndex, int pageSize)
        {
            return list.Skip(startIndex).Take(pageSize);
        }
    }
}
