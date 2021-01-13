using AutoMapper;
using HachirokuStore.Data.Models;
using HachirokuStore.Models.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace HachirokuStore.Service.Mappings
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.GoodId, act => act.MapFrom(src => src.Good.Id))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Good.Name))
                .ForMember(dest => dest.Cost, act => act.MapFrom(src => src.Good.Cost))
                .ForMember(dest => dest.PathToTitulPhoto, act => act.MapFrom(src => src.Good.PathToTitulPhoto));

        }
    }
}
