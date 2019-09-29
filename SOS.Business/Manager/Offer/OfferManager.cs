using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.Business.Utilities.Validation;
using SOS.Business.ValidationRules.FluentValidation.OfferValidation;
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

        public ISosResult GetOfferList(int customer_Id, int restaurant_Id)
        {
            var offerMenuItems = _uow.OfferDetailService.GetOfferMenuItemList(customer_Id, restaurant_Id); // OfferMenuItemList

            OfferDto offerDto = new OfferDto()
            {
                MenuItems = offerMenuItems,
                TotalPrice = offerMenuItems.Sum(s => s.Price * s.Quantity)
            };

            return offerDto.SosResult();
        }

        public ISosResult AddOfferItem(MenuItemDtoInsert menuItem, int customer_Id, int restaurant_Id, int table_Id)
        {
            // Validation kontrolü
            Validate<OfferInsertValidatior, MenuItemDtoInsert>.Valid(menuItem); 

            if (menuItem == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            // Offer tablosunda kayıt varsa id'sini al
            int? offerId = _uow.OfferService.GetOffer(customer_Id, restaurant_Id);

            // OfferDetail tablosunda kayıt varsa onu alır
            var item = _uow.OfferDetailService.Select(w => w.MenuItemId == menuItem.MenuItem_Id && w.OfferId == offerId); 

            _uow.BeginTransaction();

            // Offer tablosunda kayıt yoksa Offer tablosuna kayıt eder
            if (offerId == null) 
                offerId = (int)_uow.OfferService.Insert(new DataObjects.Entities.OfferSchema.Offer()
                {
                    Restaurant_Id = restaurant_Id,
                    StartOfferDatetime = DateTime.Now,
                    Customer_Id = customer_Id,
                    Table_Id = table_Id
                });

            // Offer tablosunda kayıt yoksa OfferDetail tablosuna kayıt eder
            if (item.Count() == 0) 
            {
                OfferDetail offerDetail = new OfferDetail()
                {
                    OfferId = offerId,
                    MenuItemId = menuItem.MenuItem_Id,
                    Quantity = menuItem.Quantity,
                    OfferNote = menuItem.OfferNote,
                    Datetime = DateTime.Now
                };

                // Kaydın id'sini alır
                var scopeId = _uow.OfferDetailService.Insert(offerDetail); 
                if (scopeId == null)
                    return HttpStatusCode.BadRequest.SosErrorResult();
            }
            else // Offer tablosunda kayıt varsa kaydı günceller
            {
                OfferDetail offerDetail = new OfferDetail()
                {
                    Id = item.First().Id,
                    OfferId = offerId,
                    MenuItemId = menuItem.MenuItem_Id,
                    Quantity = menuItem.Quantity,
                    OfferNote = menuItem.OfferNote,
                    Datetime = DateTime.Now
                };

                bool result = _uow.OfferDetailService.Update(offerDetail);
                if (result == false)
                    return HttpStatusCode.BadRequest.SosErrorResult();
            }

            _uow.Commit();

            // Kayıt edilen id'yi döndürür
            return HttpStatusCode.Created.SosOpResult(menuItem.MenuItem_Id, "Kayıt başarılı"); 

        }

        public ISosResult UpdateOfferItem(MenuItemDtoUpdate menuItem, int customer_Id, int restaurant_Id)
        {
            // Validation kontrolü
            Validate<OfferUpdateValidatior, MenuItemDtoUpdate>.Valid(menuItem); 

            if (menuItem == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            // Offer tablosunda kayıt varsa id'sini al
            int? offerId = _uow.OfferService.GetOffer(customer_Id, restaurant_Id);

            if (offerId == null)
                return HttpStatusCode.BadRequest.SosErrorResult("Offer item bulunamadı");

            // OfferDetail tablosundaki kaydı alır
            var oldOfferDetail = _uow.OfferDetailService.Select(s => s.OfferId == offerId && s.MenuItemId == menuItem.MenuItem_Id).SingleOrDefault(); 
            if (oldOfferDetail == null)
                return HttpStatusCode.BadRequest.SosErrorResult("Menu item bulunamadı");

            _uow.BeginTransaction();

            OfferDetail offerDetail = new OfferDetail()
            {
                Id = oldOfferDetail.Id,
                OfferId = offerId,
                MenuItemId = menuItem.MenuItem_Id,
                Quantity = menuItem.Quantity,
                OfferNote = menuItem.OfferNote,
                Datetime = DateTime.Now
            };

            bool result = _uow.OfferDetailService.Update(offerDetail);
            if (result == false)
                return HttpStatusCode.BadRequest.SosErrorResult();

            _uow.Commit();

            //Güncellenen edilen id'yi döndürür
            return HttpStatusCode.OK.SosOpResult(menuItem.MenuItem_Id, "Kayıt güncellendi");
        }

        public ISosResult DeleteOfferItem(int menuItem_Id, int customer_Id, int restaurant_Id)
        {
            // Offer tablosunda kaydın id'sini al
            int? offerId = _uow.OfferService.GetOffer(customer_Id, restaurant_Id);

            if (offerId == null)
                return HttpStatusCode.BadRequest.SosErrorResult("Offer item bulunamadı");

            _uow.BeginTransaction();

            _uow.OfferDetailService.OfferDetailDelete((int)offerId, menuItem_Id);

            _uow.Commit();

            return HttpStatusCode.OK.SosOpResult(menuItem_Id, "Kayıt silindi");
        }

    }
}
