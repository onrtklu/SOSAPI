using SOS.DataAccess.DapperDal.EventDal;
using SOS.DataAccess.DapperDal.MenuCategoryDal;
using SOS.DataAccess.DapperDal.MenuItemDal;
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
        IMenuItemService MenuItemService { get; }
        IRestaurantService RestaurantService { get; }
        IMenuCategoryService MenuCategoryService { get; }

        void BeginTransaction();
        void Commit();
    }
}
