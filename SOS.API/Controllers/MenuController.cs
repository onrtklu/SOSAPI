using SOS.API.Filters;
using SOS.Business.Manager.Menu;
using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.HateoasType;
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
    [RoutePrefix("api/menu")]
    public class MenuController : BaseController
    {
        private readonly IMenuManager _menuManager;
        public MenuController(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        [HttpGet]
        [Route("menu-item/{id}", Name = "MenuItem" )]
        [SwaggerResponse(HttpStatusCode.OK,"When click a menu item", typeof(SosResult<MenuItemDto>))]
        public IHttpActionResult MenuItem(int id)
        {
            var item = _menuManager.GetMenuItem(id);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("MenuItemList", null),
                Rel = "get-all-menu-item",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("OfferList", null),
                Rel = "get-list-in-offer",
                method = "GET"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("AddMenuItem", null),
                Rel = "add-item-to-offer",
                method = "POST"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("UpdateMenuItem", null),
                Rel = "update-item-to-offer",
                method = "PUT"
            });

            item.Links.Add(new Link
            {
                Href = Url.Link("DeleteMenuItem", null),
                Rel = "delete-item-to-offer",
                method = "DELETE"
            });

            return response(item);
        }

        [HttpGet]
        [Route("menu-item", Name ="MenuItemList")]
        [SwaggerResponse(HttpStatusCode.OK,"Menu item list and restaurant info", typeof(SosResult<MenuDto>))]
        [QRCode()]
        public IHttpActionResult MenuItemList()
        {
            int Restaurant_Id = GetQRCodeRestaurantId();

            var item = _menuManager.GetMenuItemList(Restaurant_Id);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("MenuItem", new { id = 0 }),
                Rel = "get-item",
                method = "GET"
            });
            item.Links.Add(new Link
            {
                Href = Url.Link("AddMenuItem", null),
                Rel = "add-item-to-offer",
                method = "POST"
            });

            return response(item);
        }

    }
}
