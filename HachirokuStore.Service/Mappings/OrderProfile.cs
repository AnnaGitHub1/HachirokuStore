using AutoMapper;
using HachirokuStore.Data.Models;
using HachirokuStore.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Service.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderInfo, Order>();
        }
    }
}
