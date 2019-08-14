using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.About;
using SOS.DataObjects.ResponseType;

namespace SOS.Business.Manager.About
{
    public class AboutManager : BaseManager, IAboutManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AboutManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult GetAbout()
        {
            AboutDto aboutDto;

            var aboutItem = _uow.AboutService.Get(1);

            if (aboutItem == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            aboutDto = _mapper.Map<AboutDto>(aboutItem);

            return aboutDto.SosResult();
        }
    }
}
