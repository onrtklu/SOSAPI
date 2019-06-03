using SOS.Core.Entities;

namespace SOS.DataObjects.Entities.CustomerSchema
{
    public class SocialMedia : BaseEntity
    {
        public int Customer_Id { get; set; }

        public string FacebookKey { get; set; }

        public string TwitterKey { get; set; }

        public string InstagramKey { get; set; }

        public string GoogleKey { get; set; }

        public string LinkedinKey { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
