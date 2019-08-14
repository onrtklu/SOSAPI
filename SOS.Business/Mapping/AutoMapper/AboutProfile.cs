using SOS.DataObjects.ComplexTypes.About;
using SOS.DataObjects.Entities.SosSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Mapping.AutoMapper
{
    public class AboutProfile : BusinessProfile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>();
        }
    }
}
