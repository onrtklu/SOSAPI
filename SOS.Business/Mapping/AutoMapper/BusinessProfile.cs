using AutoMapper;
using SOS.DataObjects.ComplexTypes.Event;
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
        }
    }
}
