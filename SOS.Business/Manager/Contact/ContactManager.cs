using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.Business.Utilities.Validation;
using SOS.Business.ValidationRules.FluentValidation.SosValidation;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.Contact;
using SOS.DataObjects.ResponseType;

namespace SOS.Business.Manager.Contact
{
    public class ContactManager : BaseManager, IContactManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ContactManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult SendMessage(ContactDtoInsert contactDtoInsert)
        {
            Validate<ContactInsertValidation, ContactDtoInsert>.Valid(contactDtoInsert);

            var result = _uow.ContactService.Insert(new DataObjects.Entities.SosSchema.Contact()
            {
                NameSurname = contactDtoInsert.NameSurname,
                Email = contactDtoInsert.Email,
                PhoneNumber = contactDtoInsert.PhoneNumber,
                Message = contactDtoInsert.Message,
                CreateDate = DateTime.Now
            });

            return HttpStatusCode.Created.SosOpResult((int)result, "Mesajınız başarıyla gönderildi");
        }
    }
}
