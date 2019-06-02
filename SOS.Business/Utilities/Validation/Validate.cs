using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Utilities.Validation
{
    public static class Validate<T,K> where T : AbstractValidator<K>, new ()
    {
        public static void Valid(K model)
        {
            T validator = new T();
            ValidationResult validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
        }
    }
}
