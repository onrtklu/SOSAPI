﻿using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.Restaurant;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Mapping.AutoMapper
{
    public class RestaurantProfile : BusinessProfile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dest => dest.CoverImageUrl, opts => opts.MapFrom(src => src.RestaurantPicture.Where(s => s.Cover == true).FirstOrDefault().PictureUrl))
                .ForMember(dest => dest.RestaurantName, opts => opts.MapFrom(src => src.RestaurantName.Trim()))
                .ForMember(dest => dest.RestaurantShortDescription, opts => opts.MapFrom(src => src.RestaurantDetail.ShortDescription.Trim()))
                .ForMember(dest => dest.RestaurantTypeName, opts => opts.MapFrom(src => src.RestaurantType.RestaurantTypeName.Trim()))
                .ForMember(dest => dest.RestaurantLogoImageUrl, opts => opts.MapFrom(src => src.LogoUrl))
                .ForMember(dest => dest.OpeningHours, opts => opts.MapFrom(src => src.RestaurantDetail.OpeningHours))
                .ForMember(dest => dest.ClosingHours, opts => opts.MapFrom(src => src.RestaurantDetail.ClosingHours))
                .ForMember(dest => dest.Wifi, opts => opts.MapFrom(src => src.RestaurantDetail.Wifi));
        }
    }
}
