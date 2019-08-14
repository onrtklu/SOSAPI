using FluentValidation;
using SOS.DataObjects.ComplexTypes.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.SosValidation
{
    public class ContactInsertValidation : AbstractValidator<ContactDtoInsert>
    {
        public ContactInsertValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email Boş Geçilemez");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Olmalıdır");
            RuleFor(s => s.Message).NotEmpty().WithMessage("Mesaj Boş Geçilemez");
        }
    }
}
