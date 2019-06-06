using SOS.Core.Entities;

namespace SOS.DataObjects.Entities.RestaurantSchema
{
    public class RestaurantPicture : BaseEntity
    {
        public string PictureName { get; set; }

        public string PictureUrl { get; set; }

        public bool? Cover { get; set; }

        public bool? IsActive { get; set; }

        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
