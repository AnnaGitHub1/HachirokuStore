using HachirokuStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HachirokuStore.Service.Interfaces
{
    public interface ICommonFilter
    {
        /// <summary>
        /// Возвращает все доступные категории
        /// </summary>
        /// <returns></returns>
        string[] FilterByCategories();

    }
}
