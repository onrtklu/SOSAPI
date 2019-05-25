using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }

        public static T GetService<T>(Core.Uow.IUnitOfWork uow)
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>(new ConstructorArgument("unitOfWork", uow));
        }
    }
}
