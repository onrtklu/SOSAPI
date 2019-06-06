using Ninject.Modules;
using SOS.Business.Account;
using SOS.Business.Manager.Event;
using SOS.Business.Manager.Menu;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.DapperDal.MenuItemDal;
using SOS.DataAccess.Uow;
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
            Bind<IEventService>().To<EventService>().InSingletonScope(); //

            Bind<IMenuManager>().To<MenuManager>().InSingletonScope();
            Bind<IMenuItemService>().To<MenuItemService>().InSingletonScope(); //

            Bind<IAccountManager>().To<AccountManager>().InSingletonScope();

            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

        }
    }
}
