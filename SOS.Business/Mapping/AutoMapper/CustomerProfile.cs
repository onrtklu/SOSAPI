using SOS.DataObjects.ComplexTypes.Customer;
using SOS.DataObjects.Entities.CustomerSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Mapping.AutoMapper
{
    public class CustomerProfile : BusinessProfile
    {
        public CustomerProfile()
        {
            CreateMap<Customers, CustomerDto>()
                .ForMember(dest => dest.BirthDate, opts => opts.MapFrom(src => src.BirthDate.Value.ToShortDateString()));
        }
    }
}
