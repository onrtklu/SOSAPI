using Ninject.Modules;
using SOS.Business.Account;
using SOS.Business.Event;
using SOS.Core.Uow;
using SOS.DataAccess.DapperDal.EventDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventManager>().To<EventManager>().InSingletonScope();
            Bind<IEventService>().To<EventService>().InSingletonScope();

            Bind<IAccountManager>().To<AccountManager>().InSingletonScope();

            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

        }
    }
}
