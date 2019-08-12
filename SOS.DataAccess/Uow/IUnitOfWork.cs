﻿using SOS.DataAccess.DapperDal.CustomerDal;
using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.DapperDal.MenuCategoryDal;
using SOS.DataAccess.DapperDal.MenuItemDal;
using SOS.DataAccess.DapperDal.Offer.OfferDal;
using SOS.DataAccess.DapperDal.Offer.OfferDetailDal;
using SOS.DataAccess.DapperDal.Order.OrderDal;
using SOS.DataAccess.DapperDal.Order.OrderDetailDal;
using SOS.DataAccess.DapperDal.RestaurantDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IEventService EventService { get; }

        IRestaurantService RestaurantService { get; }

        IMenuItemService MenuItemService { get; }
        IMenuCategoryService MenuCategoryService { get; }

        IOfferService OfferService { get; }
        IOfferDetailService OfferDetailService { get; }

        IOrderService OrderService { get; }
        IOrderDetailService OrderDetailService { get; }

        ICustomerService CustomerService { get; }

        void BeginTransaction();
        void Commit();
    }
}
