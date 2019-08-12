using FluentValidation;
using SOS.DataObjects.ComplexTypes.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class LoginValidation : AbstractValidator<LoginDto>
    {
        public LoginValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email Boş Geçilemez");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Olmalıdır");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
