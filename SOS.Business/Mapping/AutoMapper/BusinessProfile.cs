using AutoMapper;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.Entities;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Mapping.AutoMapper
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Event, Event>();
            CreateMap<EventInsertDto, Event>();

            CreateMap<MenuItem, MenuItemDto>()
                .ForMember(dest => dest.ItemName, opts => opts.MapFrom(src => src.ItemName.Trim()))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.MenuCategory.CategoryName));

            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dest => dest.CoverImageUrl, opts => opts.MapFrom(src => src.RestaurantPicture.Where(s => s.Cover == true).FirstOrDefault().PictureUrl))
                .ForMember(dest => dest.RestaurantName, opts => opts.MapFrom(src => src.RestaurantName.Trim()))
                .ForMember(dest => dest.RestaurantDescription, opts => opts.MapFrom(src => src.RestaurantDetail.Description.Trim()))
                .ForMember(dest => dest.RestaurantTypeName, opts => opts.MapFrom(src => src.RestaurantType.RestaurantTypeName.Trim()));

            CreateMap<MenuItem, Menu_MenuItemDto>()
                .ForMember(dest => dest.ItemName, opts => opts.MapFrom(src => src.ItemName.Trim()))
                .ForMember(dest => dest.ItemDescription, opts => opts.MapFrom(src => src.Description.Trim()));
        }
    }
}
