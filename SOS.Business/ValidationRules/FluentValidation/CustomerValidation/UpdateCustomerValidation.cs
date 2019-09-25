using FluentValidation;
using SOS.DataObjects.ComplexTypes.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation.CustomerValidation
{
    public class UpdateCustomerValidation : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerValidation()
        {
            RuleFor(s => s.PhoneNumber)
                .Matches("(([\\+]90?)|([0]?))([ ]?)((\\([0-9]{3}\\))|([0-9]{3}))([ ]?)([0-9]{3})(\\s*[\\-]?)([0-9]{2})(\\s*[\\-]?)([0-9]{2})")
                .WithMessage("Geçerli bir telefon numarası olmalıdır");
        }
    }
}
