using SOS.Business.DependencyResolvers.Ninject;
using SOS.DataAccess.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager
{
    public class BaseManager
    {
        protected IDalSession InstanceDalSession()
        {
            return InstanceFactory.GetDalSession();
        }
    }
}
