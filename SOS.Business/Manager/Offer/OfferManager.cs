using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.ComplexTypes.Offer;
using SOS.DataObjects.Entities.OfferSchema;
using SOS.DataObjects.Entities.RestaurantSchema;
using SOS.DataObjects.ResponseType;

namespace SOS.Business.Manager.Offer
{
    public class OfferManager : BaseManager, IOfferManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OfferManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult GetOfferList(int customer_Id)
        {
            var offerMenuItems = _uow.OfferDetailService.GetOfferMenuItemList(customer_Id);

            if (offerMenuItems == null)
                HttpStatusCode.BadRequest.SosErrorResult();

            OfferDto offerDto = new OfferDto()
            {
                MenuItems = offerMenuItems,
                TotalPrice = offerMenuItems.Sum(s => s.Price * s.Quantity)
            };

            return offerDto.SosResult();
        }

        public ISosResult AddOfferItem(MenuItemDtoInsert menuItem, int customer_Id)
        {

            if(menuItem == null)
                return HttpStatusCode.NoContent.SosErrorResult();
                       
            int? offerId = GetOffer(customer_Id);

            if (offerId == null)
                offerId = (int)_uow.OfferService.Insert(new DataObjects.Entities.OfferSchema.Offer()
                {
                    StartOfferDatetime = DateTime.Now,
                    Customer_Id = customer_Id
                });


            _uow.BeginTransaction();

            OfferDetail offerDetail = new OfferDetail()
            {
                OfferId = offerId,
                MenuItemId = menuItem.Id,
                Quantity = menuItem.Quantity,
                Datetime = DateTime.Now
            };

            var scopeId = _uow.OfferDetailService.Insert(offerDetail);
            if (scopeId == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            _uow.Commit();


            return HttpStatusCode.Created.SosOpResult(Convert.ToInt32(menuItem.Id));

        }

        public ISosResult UpdateOfferItem(MenuItemDtoUpdate menuItem, int customer_Id)
        {

            if (menuItem == null)
                return HttpStatusCode.NoContent.SosErrorResult();

            int? offerId = GetOffer(customer_Id);

            var oldOfferDetail = _uow.OfferDetailService.Select(s => s.OfferId == offerId && s.MenuItemId == menuItem.Id);
            if (oldOfferDetail == null)
                return HttpStatusCode.NoContent.SosErrorResult();

            _uow.BeginTransaction();

            OfferDetail offerDetail = new OfferDetail()
            {
                Id = oldOfferDetail.First().Id,
                OfferId = offerId,
                MenuItemId = menuItem.Id,
                Quantity = menuItem.Quantity,
                Datetime = DateTime.Now
            };

            bool result = _uow.OfferDetailService.Update(offerDetail);
            if (result == false)
                return HttpStatusCode.BadRequest.SosErrorResult();

            _uow.Commit();

            return HttpStatusCode.OK.SosOpResult(menuItem.Id);
        }

        public ISosResult DeleteOfferItem(int menuItem_Id, int customer_Id)
        {
            int? offerId = GetOffer(customer_Id);

            bool result = _uow.OfferDetailService.DeleteMultiple(s => s.OfferId == offerId && s.MenuItemId == menuItem_Id);
            if (result == false)
                return HttpStatusCode.BadRequest.SosErrorResult();
            
            return HttpStatusCode.OK.SosOpResult(menuItem_Id);
        }


        #region Method

        private int? GetOffer(int customer_Id)
        {
            var item = _uow.OfferService.Select(s => s.Customer_Id == customer_Id).FirstOrDefault();

            return item?.Id;
        }

        #endregion

    }
}
