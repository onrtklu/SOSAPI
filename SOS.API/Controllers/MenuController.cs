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

            var category_Id = _menuManager.GetCategoryIdByMenuItem(id);
            item.Links.Add(new Link
            {
                Href = Url.Link("MenuItemListByCategory", new { category_Id = category_Id ?? 0 }),
                Rel = "get-item-by-category",
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
        public IHttpActionResult MenuItemList()
        {
            int Restaurant_Id = 1;

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

        [HttpGet]
        [Route("category", Name = "MenuCategoryList")]
        [SwaggerResponse(HttpStatusCode.OK, "Category list and restaurant info", typeof(SosResult<MenuCategoriesDto>))]
        public IHttpActionResult MenuCategoryList()
        {
            int Restaurant_Id = 1;

            var item = _menuManager.GetMenuCategoryList(Restaurant_Id);

            item.Links = new List<ILink>();

            item.Links.Add(new Link
            {
                Href = Url.Link("MenuItemListByCategory", new { category_Id = 0 }),
                Rel = "get-item-by-category",
                method = "GET"
            });

            return response(item);
        }

        [HttpGet]
        [Route("category/{category_Id}/menu-item", Name = "MenuItemListByCategory")]
        [SwaggerResponse(HttpStatusCode.OK, "Menu item list by category and restaurant info", typeof(SosResult<MenuItemByCategoryDto>))]
        public IHttpActionResult MenuItemListByCategory(int category_Id)
        {
            var item = _menuManager.GetMenuItemListByCategory(category_Id);

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
