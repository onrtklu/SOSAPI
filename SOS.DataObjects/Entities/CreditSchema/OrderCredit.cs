using SOS.Core.Entities;
using SOS.DataObjects.Entities.CustomerSchema;
using SOS.DataObjects.Entities.OrdersSchema;
using SOS.DataObjects.Entities.RestaurantSchema;

namespace SOS.DataObjects.Entities.CreditSchema
{

    public partial class OrderCredit : BaseEntity
    {
        public int? Restaurant_Id { get; set; }

        public int? Credit_Id { get; set; }

        public int? Order_Id { get; set; }

        public int? Customer_Id { get; set; }

        public virtual Credit Credit { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
