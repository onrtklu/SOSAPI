using Ninject;
using Ninject.Parameters;
using SOS.Core.Utilities;
using SOS.DataAccess.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        private static StandardKernel _standartKernel = null;

        private static StandardKernel StandartKernel => _standartKernel ?? new StandardKernel(Singleton<BusinessModule>.Instance);

        public static T GetInstance<T>()
        {
            var kernel = StandartKernel;
            return kernel.Get<T>();
        }

        public static T GetService<T>(Core.Uow.IUnitOfWork uow)
        {
            var kernel = StandartKernel;
            return kernel.Get<T>(new ConstructorArgument("unitOfWork", uow));
        }

        public static IDalSession GetDalSession()
        {
            var kernel = StandartKernel;
            return kernel.Get<IDalSession>();
        }
    }
}
