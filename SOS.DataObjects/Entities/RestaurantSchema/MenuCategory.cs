namespace SOS.DataObjects.Entities.RestaurantSchema
{
    using SOS.Core.Entities;
    using System;
    using System.Collections.Generic;

    public class MenuCategory : BaseEntity
    {
        public MenuCategory()
        {
            MenuCategorySub = new HashSet<MenuCategory>();
            MenuItem = new HashSet<MenuItem>();
        }

        public int? Parent_Id { get; set; }

        public string CategoryName { get; set; }

        public int Restaurant_Id { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<MenuCategory> MenuCategorySub { get; set; }

        public virtual MenuCategory MenuCategoryTop { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
