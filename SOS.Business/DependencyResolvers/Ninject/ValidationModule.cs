using FluentValidation;
using Ninject.Modules;
using SOS.Business.ValidationRules.FluentValidation;
using SOS.DataObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
        }
    }
}
