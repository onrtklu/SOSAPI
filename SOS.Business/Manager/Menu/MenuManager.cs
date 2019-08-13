using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.Menu;
using SOS.DataObjects.ComplexTypes.MenuItem;
using SOS.DataObjects.ComplexTypes.Restaurant;
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
            MenuItem resultMenuItem;
            MenuItemDto resultMenuItemDto;

            if (_uow.OfferDetailService.IsMenuItemAdded(Id, 1)) // offer'a ekli olup olmadığına bakılır
            {
                resultMenuItemDto = _uow.OfferDetailService.GetMenuItemFromOffer(Id, 1); //offer'da varsa offer'dan getirir
                if (resultMenuItemDto == null)
                    return HttpStatusCode.BadRequest.SosErrorResult();
            }
            else
            {
                resultMenuItem = _uow.MenuItemService.GetWithCategory(Id); // offer'da yoksa menuItem'dan getirir
                if (resultMenuItem == null)
                    return HttpStatusCode.BadRequest.SosErrorResult();

                resultMenuItemDto = _mapper.Map<MenuItemDto>(resultMenuItem);
            }

            return resultMenuItemDto.SosResult();
        }

        public ISosResult GetMenuItemList(int Restaurant_Id)
        {
            var restaurant = _uow.RestaurantService.GetRestaurant(Restaurant_Id);

            var categoryList = _uow.MenuCategoryService.Select(s => s.Restaurant_Id == Restaurant_Id);

            var menuItems = _uow.MenuItemService.Select(s => s.Restaurant_Id == Restaurant_Id);

            if (restaurant == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            var mappedRestaurant = _mapper.Map<RestaurantDto>(restaurant);

            foreach (var menuItem in menuItems)
            {
                categoryList.Where(s => s.Id == menuItem.MenuCategoryId).SingleOrDefault().MenuItem.Add(menuItem);
            }

            var mappedCategoryList = _mapper.Map<List<Menu_CategoryDto>>(categoryList);
            var mappedMenuItems = _mapper.Map<List<Menu_MenuItemDto>>(menuItems);

            mappedCategoryList = mappedCategoryList.Where(s => s.MenuItems.Count != 0).ToList();

            MenuDto menuDto = new MenuDto()
            {
                Restaurant = mappedRestaurant,
                CategoryItems = mappedCategoryList
            };

            return menuDto.SosResult();
        }

    }
}
