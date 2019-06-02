using FluentValidation;
using SOS.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.ValidationRules.FluentValidation
{
    public class EventValidatior : AbstractValidator<Event>
    {
        public EventValidatior()
        {
            RuleFor(s => s.PlayID).NotEqual(0).WithMessage("oyun boş geçilemez");
            RuleFor(s => s.HallID).NotEqual(0).WithMessage("salon boş geçilemez");
        }
    }
}
