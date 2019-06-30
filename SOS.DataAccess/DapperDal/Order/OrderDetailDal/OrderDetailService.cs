using Dapper;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.ComplexTypes.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.Order.OrderDetailDal
{
    public class OrderDetailService : DapperGenericRepository<DataObjects.Entities.OrdersSchema.OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<OrderMenuItemList> GetOrderDetailList(int order_Id)
        {
            var item = _connection.Query<OrderMenuItemList>("Orders.GetOrderMenuItemList",
                new { Order_ID = order_Id },
                _transaction,
                commandType: CommandType.StoredProcedure);

            return item;
        }
    }
}
