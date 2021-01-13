using HachirokuStore.Models.Enums;
using HachirokuStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HachirokuStore.Service
{
    public class CommonFilterService : ICommonFilter
    {
        public CommonFilterService()
        {

        }

        public string[] FilterByCategories()
        {
            return Enum.GetNames(typeof(GoodCategory));
        }
    }
}
