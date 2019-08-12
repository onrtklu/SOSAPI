using FluentValidation;
using SOS.DataObjects.ComplexTypes.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(s => s.Email).NotEmpty().WithMessage("Email Boş Geçilemez");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Olmalıdır");
            RuleFor(s => s.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(s => s.PasswordConfirm).NotEmpty().WithMessage("Şifre Doğrulama Boş Geçilemez");
            RuleFor(s=>s.Password).Equal(s=>s.PasswordConfirm).WithMessage("Şifreler Eşit Olmalı");
        }
    }
}
