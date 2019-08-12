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
        }
    }
}
