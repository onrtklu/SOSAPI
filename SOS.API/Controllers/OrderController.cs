﻿using SOS.Business.Manager.Order;
using SOS.DataObjects.ComplexTypes.Order;
using SOS.DataObjects.ResponseType;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOS.API.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : BaseController
    {
        private readonly IOrderManager _orderManager;
        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }


        [HttpGet]
        [Route("order-list", Name = "OrderList")]
        [SwaggerResponse(HttpStatusCode.OK, "Order list", typeof(SosResult<IEnumerable<OrderListDto>>))]
        public IHttpActionResult GetOrderList()
        {
            int customer_Id = 1;
            int restaurant_Id = 1;

            var item = _orderManager.OrderList(customer_Id, restaurant_Id);

            return Ok(item);
        }

        [HttpGet]
        [Route("order-detail-list", Name = "OrderDetailList")]
        [SwaggerResponse(HttpStatusCode.OK, "Order detail list and menu items", typeof(SosResult<OrderDto>))]
        public IHttpActionResult GetOrderDetailList(int order_Id)
        {
            var item = _orderManager.OrderDetailList(order_Id);

            return Ok(item);
        }

        [HttpPost]
        [Route("complete-order-online", Name = "CompleteOrderByOnline")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "complete order by online", Type = typeof(SosOpResult))]
        public IHttpActionResult CompleteOrderByOnline()
        {
            int customer_Id = 1;
            int restaurant_Id = 1;

            var item = _orderManager.CompleteOrderByOnline(customer_Id, restaurant_Id);

            return Ok(item);
        }

        [HttpPost]
        [Route("complete-order-cash", Name = "CompleteOrderByCash")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "complete order by cash", Type = typeof(SosOpResult))]
        public IHttpActionResult CompleteOrderByCash()
        {
            int customer_Id = 1;
            int restaurant_Id = 1;

            var item = _orderManager.CompleteOrderByCash(customer_Id, restaurant_Id);

            return Ok(item);
        }

    }
}
