using AutoMapper;
using SOS.DataObjects.ComplexTypes.Event;
using SOS.DataObjects.Entities;
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
        }
    }
}
