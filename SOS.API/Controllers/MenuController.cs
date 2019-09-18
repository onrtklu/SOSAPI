using SOS.API.Filters;
using SOS.Business.Manager.Menu;
using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
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
            int customer_Id = GetUserId();

            var item = _menuManager.GetMenuItem(id, customer_Id);

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

            return response(item);
        }

    }
}
