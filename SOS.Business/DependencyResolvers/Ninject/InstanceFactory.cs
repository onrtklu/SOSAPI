using Ninject;
using Ninject.Parameters;
using SOS.Core.Utilities;
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
        
    }
}
