using FluentValidation;
using SOS.DataObjects.ComplexTypes.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidation()
        {
            RuleFor(s => s.OldPassword).NotEmpty().WithMessage("Eski şifre boş geçilemez");
            RuleFor(s => s.NewPassword).NotEmpty().WithMessage("Yeni şifre boş geçilemez")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$").WithMessage("Şifre en az 8 karakter, büyük harf, küçük harf ve sayı içermelidir");
            RuleFor(s => s.NewPasswordConfirm).NotEmpty().WithMessage("Yeni şifre doğrulama boş geçilemez");
            RuleFor(s=>s.NewPassword).Equal(s=>s.NewPasswordConfirm).WithMessage("Şifreler eşit olmalıdır");
        }
    }
}
