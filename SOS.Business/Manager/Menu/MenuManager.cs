using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.Entities.RestaurantSchema;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Menu
{
    public class MenuManager : BaseManager, IMenuManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MenuManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult GetMenuItem(int Id)
        {
            MenuItem result;

            if (_uow.OfferDetailService.IsMenuItemAdded(Id, 1))
                result = _uow.OfferDetailService.GetMenuItemFromOffer(Id, 1);
            else
                result = _uow.MenuItemService.GetWithCategory(Id);

            if (result == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var mapped = _mapper.Map<MenuItemDto>(result);

            return mapped.SosResult();
        }

        public ISosResult GetMenuItemList(int Restaurant_Id)
        {
            var restaurant = _uow.RestaurantService.GetRestaurant(Restaurant_Id);

            var menuItems = _uow.MenuItemService.Select(s => s.Restaurant_Id == Restaurant_Id);

            if (restaurant == null || menuItems == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var mappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);
            var mappedMenuItems = _mapper.Map<List<Menu_MenuItemDto>>(menuItems);

            MenuDto menuDto = new MenuDto()
            {
                Restaurant = mappedRestaurant,
                MenuItems = mappedMenuItems
            };

            return menuDto.SosResult();
        }

        public ISosResult GetMenuCategoryList(int Restaurant_Id)
        {
            var restaurant = _uow.RestaurantService.GetRestaurant(Restaurant_Id);

            var categoryList = _uow.MenuCategoryService.Select(s => s.Restaurant_Id == Restaurant_Id);

            if (restaurant == null || categoryList == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var mappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);
            var mappedCategoryItems = _mapper.Map<List<Menu_CategoryDto>>(categoryList);

            MenuCategoriesDto menuDto = new MenuCategoriesDto()
            {
                Restaurant = mappedRestaurant,
                CategoryItems = mappedCategoryItems
            };

            return menuDto.SosResult();
        }

        public ISosResult GetMenuItemListByCategory(int Category_Id)
        {
            var category = _uow.MenuCategoryService.Get(Category_Id);

            if (category == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var restaurant = _uow.RestaurantService.GetRestaurant(category.Restaurant_Id);

            var menuItems = _uow.MenuItemService.Select(s => s.MenuCategoryId == Category_Id);

            if (restaurant == null || menuItems == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var mappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);
            var mappedCategory = _mapper.Map<Menu_CategoryDto>(category);
            var mappedMenuItems = _mapper.Map<List<Menu_MenuItemDto>>(menuItems);

            MenuItemByCategoryDto menuDto = new MenuItemByCategoryDto()
            {
                Restaurant = mappedRestaurant,
                Category = mappedCategory,
                MenuItems = mappedMenuItems
            };

            return menuDto.SosResult();
        }



        public int? GetCategoryIdByMenuItem(int menuItem_Id)
        {
            var item = _uow.MenuItemService.Get(menuItem_Id);

            return item.MenuCategoryId;
        }
    }
}
