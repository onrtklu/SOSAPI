using Ninject.Modules;
using SOS.Business.Account;
using SOS.Business.Manager.Customer;
using SOS.Business.Manager.Event;
using SOS.Business.Manager.Menu;
using SOS.Business.Manager.Offer;
using SOS.Business.Manager.Order;
using SOS.DataAccess.DapperDal.CustomerDal;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.DapperDal.MenuItemDal;
using SOS.DataAccess.DapperDal.Offer.OfferDal;
using SOS.DataAccess.DapperDal.Offer.OfferDetailDal;
using SOS.DataAccess.DapperDal.Order.OrderDal;
using SOS.DataAccess.DapperDal.Order.OrderDetailDal;
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

            Bind<IOfferManager>().To<OfferManager>().InSingletonScope();
            Bind<IOfferService>().To<OfferService>().InSingletonScope();
            Bind<IOfferDetailService>().To<OfferDetailService>().InSingletonScope(); //

            Bind<IOrderManager>().To<OrderManager>().InSingletonScope();
            Bind<IOrderService>().To<OrderService>().InSingletonScope();
            Bind<IOrderDetailService>().To<OrderDetailService>().InSingletonScope(); //

            Bind<IAccountManager>().To<AccountManager>().InSingletonScope();

            Bind<ICustomerManager>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerService>().To<CustomerService>().InSingletonScope(); //

            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

        }
    }
}
