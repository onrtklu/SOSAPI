using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel.Customer
{
    public class CustomerMap : DommelEntityMap<DataObjects.Entities.CustomerSchema.Customers>
    {
        public CustomerMap()
        {
            ToTable("Customers", "Customer");

            Map(s => s.CustomerCredit).Ignore();
            Map(s => s.OrderCredit).Ignore();
            Map(s => s.SocialMedia).Ignore();
            Map(s => s.Offer).Ignore();
            Map(s => s.Orders).Ignore();
            Map(s => s.RestaurantComments).Ignore();
        }
    }
}
