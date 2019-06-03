using SOS.Core.Entities;

namespace SOS.DataObjects.Entities.RestaurantSchema
{
    public class Rate : BaseEntity
    {
        public int? Restaurant_Comment_Id { get; set; }

        public int? OrderRate { get; set; }

        public int? RestaurantRate { get; set; }

        public int? FoodRate { get; set; }

        public int? ServiceRate { get; set; }

        public int? WaiterRate { get; set; }

        public virtual RestaurantComments RestaurantComments { get; set; }
    }
}
