using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataObjects.ComplexTypes.Menu
{
    /// <summary>
    /// Menu with menu items
    /// </summary>
    public class MenuDto
    {
        public RestaurantDto Restaurant { get; set; }
        public IEnumerable<Menu_MenuItemDto> MenuItems { get; set; }
    }

    public class RestaurantDto
    {
        public int Id { get; set; }
        public string CoverImageUrl { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantLogoImageUrl { get; set; }
        public decimal Rate { get; set; }
        public string RestaurantTypeName { get; set; }
        public int EstimatedServiceTime { get; set; }
    }

    public class Menu_MenuItemDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int StrikethroughPrice { get; set; }
        public int Price { get; set; }
    }

    /// <summary>
    /// Menu with menu categories
    /// </summary>
    public class MenuCategoriesDto
    {
        public RestaurantDto Restaurant { get; set; }
        public int MyProperty { get; set; }
    }

    public class Menu_CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
    }
}
