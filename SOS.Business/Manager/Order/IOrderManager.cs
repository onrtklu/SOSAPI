using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Order
{
    public interface IOrderManager
    {
        ISosResult CompleteOrderByOnline(int customer_Id, int restaurant_Id);

        ISosResult CompleteOrderByCash(int customer_Id, int restaurant_Id);

        ISosResult OrderList(int customer_Id, int restaurant_Id);

        ISosResult OrderDetailList(int order_Id);
    }
}
