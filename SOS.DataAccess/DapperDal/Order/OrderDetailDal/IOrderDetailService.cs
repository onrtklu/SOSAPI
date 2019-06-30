using SOS.Core.DataAccess;
using SOS.DataObjects.ComplexTypes.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Order.OrderDetailDal
{
    public interface IOrderDetailService : IGenericRepository<DataObjects.Entities.OrdersSchema.OrderDetail>
    {
        IEnumerable<OrderMenuItemList> GetOrderDetailList(int order_Id);
    }
}
