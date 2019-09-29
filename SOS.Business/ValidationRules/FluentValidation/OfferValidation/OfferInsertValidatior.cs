using FluentValidation;
using SOS.DataObjects.ComplexTypes.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.OfferValidation
{
    public class OfferInsertValidatior : AbstractValidator<MenuItemDtoInsert>
    {
        public OfferInsertValidatior()
        {
            RuleFor(s => s.MenuItem_Id).NotEmpty().WithMessage("Id boş geçilemez");
            RuleFor(s => s.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Miktar 0 ve daha azı olamaz")
                .NotEmpty().WithMessage("Miktar boş geçilemez");
        }
    }

}
