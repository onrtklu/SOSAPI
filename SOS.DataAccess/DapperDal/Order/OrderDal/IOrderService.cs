using SOS.Core.DataAccess;
using SOS.DataObjects.ComplexTypes.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Order.OrderDal
{
    public interface IOrderService : IGenericRepository<DataObjects.Entities.OrdersSchema.Order>
    {
        IEnumerable<OrderListDto> GetOrderList(int customerId, int restaurant_Id);

        OrderDto GetOrder(int order_Id);
    }
}
