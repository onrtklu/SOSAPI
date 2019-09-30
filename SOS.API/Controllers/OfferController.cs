using SOS.API.ExcHand;
using SOS.API.Filters;
using SOS.Business.Manager.Offer;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.ComplexTypes.Offer;
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
    [RoutePrefix("api/offer")]
    public class OfferController : BaseController
    {
        private readonly IOfferManager _offerManager;
        public OfferController(IOfferManager offerManager)
        {
            _offerManager = offerManager;
        }

        [HttpGet]
        [Route("offer-list", Name = "OfferList")]
        [SwaggerResponse(HttpStatusCode.OK, "Menu item list from the offer", typeof(SosResult<IEnumerable<OfferDto>>))]
        [SosAuthorize]
        [QRCode]
        public IHttpActionResult GetOfferList()
        {
            int customer_Id = GetUserId();
            int restaurant_Id = GetQRCodeRestaurantId();

            var item = _offerManager.GetOfferList(customer_Id, restaurant_Id);

            return Ok(item);
        }
        
        [HttpPost]
        [Route("menu-item", Name = "AddMenuItem")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "add a menu item to the offer", Type = typeof(SosOpResult))]
        [SosAuthorize]
        [QRCode]
        public IHttpActionResult Post([FromBody]MenuItemDtoInsert value)
        {
            int customer_Id = GetUserId();
            int restaurant_Id = GetQRCodeRestaurantId();
            int table_Id = GetQRCodeTableId();

            var item = _offerManager.AddOfferItem(value, customer_Id, restaurant_Id, table_Id);

            return Ok(item);

        }

        [HttpPut]
        [Route("menu-item", Name = "UpdateMenuItem")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "update a menu item to the offer", Type = typeof(SosOpResult))]
        [SosAuthorize]
        [QRCode]
        public IHttpActionResult Put([FromBody]MenuItemDtoUpdate value)
        {
            int customer_Id = GetUserId();
            int restaurant_Id = GetQRCodeRestaurantId();

            var item = _offerManager.UpdateOfferItem(value, customer_Id, restaurant_Id);

            return Ok(item);
        }

        [HttpDelete]
        [Route("menu-item", Name = "DeleteMenuItem")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "delete a menu item to the offer", Type = typeof(SosOpResult))]
        [SosAuthorize]
        [QRCode]
        public IHttpActionResult Delete(int menuItem_Id)
        {
            int customer_Id = GetUserId();
            int restaurant_Id = GetQRCodeRestaurantId();

            var item = _offerManager.DeleteOfferItem(menuItem_Id, customer_Id, restaurant_Id);

            return Ok(item);
        }
    }
}
