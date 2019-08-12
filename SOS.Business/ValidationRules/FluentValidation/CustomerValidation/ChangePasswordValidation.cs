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
            RuleFor(s => s.OldPassword).NotEmpty().WithMessage("Eski Şifre Boş Geçilemez");
            RuleFor(s => s.NewPassword).NotEmpty().WithMessage("Yeni Şifre Boş Geçilemez");
            RuleFor(s => s.NewPasswordConfirm).NotEmpty().WithMessage("Yeni Şifre Doğrulama Boş Geçilemez");
            RuleFor(s=>s.NewPassword).Equal(s=>s.NewPasswordConfirm).WithMessage("Şifreler Eşit Olmalı");
        }
    }
}
