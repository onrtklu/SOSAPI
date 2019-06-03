namespace SOS.DataObjects.Entities.CreditSchema
{
    using SOS.Core.Entities;
    using System.Collections.Generic;

    public class Credit : BaseEntity
    {
        public Credit()
        {
            CustomerCredit = new HashSet<CustomerCredit>();
            OrderCredit = new HashSet<OrderCredit>();
        }

        public string CreditName { get; set; }

        public int? CreditRate { get; set; }

        public virtual ICollection<CustomerCredit> CustomerCredit { get; set; }

        public virtual ICollection<OrderCredit> OrderCredit { get; set; }
    }
}
