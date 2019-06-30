using Dapper;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.ComplexTypes.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Order.OrderDal
{
    public class OrderService : DapperGenericRepository<DataObjects.Entities.OrdersSchema.Order>, IOrderService
    {
        public OrderService(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<OrderListDto> GetOrderList(int customerId, int restaurant_Id)
        {
            var item = _connection.Query<OrderListDto>("Orders.GetOrderList",
                new { Customer_ID = customerId, Restaurant_Id = restaurant_Id },
                _transaction,
                commandType: CommandType.StoredProcedure);

            return item;
        }

        public OrderDto GetOrder(int order_Id)
        {
            var item = _connection.Query<OrderDto>("Orders.GetOrder",
                new { Order_ID = order_Id },
                _transaction,
                commandType: CommandType.StoredProcedure);

            return item.SingleOrDefault();
        }
    }
}
