using AutoMapper;
using HachirokuStore.Data.Models;
using HachirokuStore.Models.Goods;
using HachirokuStore.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HachirokuStore.Service.Mappings
{
    public class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            CreateMap<Good, GoodSummary>()
                .ForMember(dest => dest.PathToTitulPhoto, act => act.MapFrom(src => src.PathsToPhotos.FirstOrDefault()));

            CreateMap<Good, GoodFullDescription>()
                .ForMember(dest => dest.GoodCategory, act => act.MapFrom(src => EnumsExtensions.GetEnumDescription(src.GoodCategory)));

        }
    }
}
