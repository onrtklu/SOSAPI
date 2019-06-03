using SOS.Core.Entities;
using SOS.DataObjects.Entities.CustomerSchema;

namespace SOS.DataObjects.Entities.CreditSchema
{

    public class CustomerCredit : BaseEntity
    {
        public int Customer_Id { get; set; }

        public int Credit_Id { get; set; }

        public virtual Credit Credit { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
