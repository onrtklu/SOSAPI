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

        [Route("menu-item", Name = "MenuItem" )]
        [SwaggerResponse(HttpStatusCode.OK,"When click a menu item", typeof(SosResult<MenuItemDto>))]
        public IHttpActionResult Get(int id)
        {
            var item = _menuManager.GetMenuItem(id);

            //item.Links = new List<ILink>();

            //item.Links.Add(new Link
            //{
            //    Href = Url.Link("GetAll", null),
            //    Rel = "get-all-event",
            //    method = "GET"
            //});

            return response(item);
        }

        [Route("menu-list", Name ="MenuList")]
        [SwaggerResponse(HttpStatusCode.OK,"Menu item list and restaurant info", typeof(SosResult<MenuDto>))]
        public IHttpActionResult GetList(int Restaurant_Id)
        {
            var item = _menuManager.GetMenuList(Restaurant_Id);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("MenuItem", new { id = 0 }),
                Rel = "get-item",
                method = "GET"
            });

            return response(item);
        }
    }
}
