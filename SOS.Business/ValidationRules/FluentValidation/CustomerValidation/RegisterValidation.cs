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
            RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("Email boş geçilemez");

            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage("Geçerli bir email adresi olmalıdır");

            RuleFor(s => s.Password)
                .NotEmpty()
                .WithMessage("Şifre boş geçilemez")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$")
                .WithMessage("Şifre en az 8 karakter, büyük harf, küçük harf ve sayı içermelidir");

            RuleFor(s => s.PasswordConfirm)
                .NotEmpty()
                .WithMessage("Şifre doğrulama boş geçilemez");

            RuleFor(s=>s.Password)
                .Equal(s=>s.PasswordConfirm)
                .WithMessage("Şifreler eşit olmalı");

            RuleFor(s => s.PhoneNumber)
                .Matches("(([\\+]90?)|([0]?))([ ]?)((\\([0-9]{3}\\))|([0-9]{3}))([ ]?)([0-9]{3})(\\s*[\\-]?)([0-9]{2})(\\s*[\\-]?)([0-9]{2})")
                .WithMessage("Geçerli bir telefon numarası olmalıdır");
        }
    }
}
