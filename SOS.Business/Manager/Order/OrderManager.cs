using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.Order;
using SOS.DataObjects.Enums;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Order
{
    public class OrderManager : IOrderManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult CompleteOrderByOnline(int customer_Id, int restaurant_Id)
        {
            return CompleteOrder(customer_Id, restaurant_Id, PaymentType.Online);
        }

        public ISosResult CompleteOrderByCash(int customer_Id, int restaurant_Id)
        {
            return CompleteOrder(customer_Id, restaurant_Id, PaymentType.Kasada);
        }

        public ISosResult OrderList(int customer_Id, int restaurant_Id)
        {
            var result = _uow.OrderService.GetOrderList(customer_Id, restaurant_Id);

            return result.SosResult();
        }

        public ISosResult OrderDetailList(int order_Id)
        {
            var order = _uow.OrderService.GetOrder(order_Id); // OrderDto tipinde
            var orderMenuItemList = _uow.OrderDetailService.GetOrderDetailList(order_Id); // Order'a ait OrderDetail verileri

            if (order == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            order.MenuItems = orderMenuItemList; // Order'ın detayları eklenir

            return order.SosResult();
        }

        #region Method

        private ISosResult CompleteOrder(int customer_Id, int restaurant_Id, PaymentType paymentType)
        {
            // Offer 
            var offer = _uow.OfferService.Select(s => s.Customer_Id == customer_Id && s.Restaurant_Id == restaurant_Id).FirstOrDefault();

            if (offer == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            // Offer Detail list 
            var offerMenuItems = _uow.OfferDetailService.GetOfferMenuItemList(customer_Id, restaurant_Id); // OfferMenuItemList


            _uow.BeginTransaction();

            // Order tablosuna eklenir
            var orderId = _uow.OrderService.Insert(new DataObjects.Entities.OrdersSchema.Order()
            {
                Restaurant_Id = offer.Restaurant_Id,
                OrderTime = DateTime.Now,
                Customer_Id = customer_Id,
                TotalPrice = offerMenuItems.Sum(s => s.Price * s.Quantity),
                Discount = 0,
                FinalPrice = offerMenuItems.Sum(s => s.Price * s.Quantity),
                OrderStatus_Id = (int)OrderStatus.SiparisBekleniyor,
                PaymentType_Id = (int)paymentType,
                Datetime = DateTime.Now
            });

            //Her offer detail, order detail tablosuna eklenir
            foreach (var item in offerMenuItems)
            {
                var scopeId = _uow.OrderDetailService.Insert(new DataObjects.Entities.OrdersSchema.OrderDetail()
                {
                    Order_Id = (int)orderId,
                    MenuItem_Id = item.MenuItem_Id,
                    Quantity = item.Quantity,
                    OrderNote = item.OfferNote,
                    ItemPrice = item.Price,
                    TotalPrice = item.Price * item.Quantity
                });
            }

            // Offer tablosundan kayıtlar silinir
            _uow.OfferDetailService.DeleteMultiple(s => s.OfferId == offer.Id);
            _uow.OfferService.DeleteMultiple(s => s.Id == offer.Id);

            _uow.Commit();

            // Kayıt edilen id'yi döndürür
            return HttpStatusCode.Created.SosOpResult((int)orderId, "Kayıt başarılı");
        }

        #endregion
    }
}
