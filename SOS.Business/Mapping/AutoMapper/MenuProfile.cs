using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Mapping.AutoMapper
{
    public class MenuProfile : BusinessProfile
    {
        public MenuProfile()
        {
            CreateMap<MenuItem, MenuItemDto>()
                .ForMember(dest => dest.ItemName, opts => opts.MapFrom(src => src.ItemName.Trim()))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.MenuCategory.CategoryName));

            CreateMap<MenuItem, Menu_MenuItemDto>()
                .ForMember(dest => dest.ItemName, opts => opts.MapFrom(src => src.ItemName.Trim()))
                .ForMember(dest => dest.ItemIngredients, opts => opts.MapFrom(src => src.Ingredients.Trim()));

            CreateMap<MenuCategory, Menu_CategoryDto>()
                .ForMember(dest => dest.CategoryImageUrl, opts => opts.MapFrom(src => src.ImageUrl));

        }
    }
}
