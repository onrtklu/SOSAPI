using FluentValidation;
using SOS.DataObjects.ComplexTypes.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.OfferValidation
{
    public class OfferUpdateValidatior : AbstractValidator<MenuItemDtoUpdate>
    {
        public OfferUpdateValidatior()
        {
            RuleFor(s => s.MenuItem_Id).NotEmpty().WithMessage("Id boş geçilemez");
            RuleFor(s => s.Quantity).NotEmpty().WithMessage("Miktar boş geçilemez");
        }
    }
}
