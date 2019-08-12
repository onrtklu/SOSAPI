using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using SOS.DataAccess.Mapping.Dommel.Customer;
using SOS.DataAccess.Mapping.Dommel.Offer;
using SOS.DataAccess.Mapping.Dommel.Order;
using SOS.DataAccess.Mapping.Dommel.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.Mapping.Dommel
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new EventMap());

                config.AddMap(new RestaurantMap());
                config.AddMap(new RestaurantDetailMap());
                config.AddMap(new RestaurantTypeMap());
                config.AddMap(new RestaurantPictureMap());

                config.AddMap(new MenuItemMap());
                config.AddMap(new MenuCategoryMap());

                config.AddMap(new OfferMap());
                config.AddMap(new OfferDetailMap());

                config.AddMap(new OrderMap());
                config.AddMap(new OrderDetailMap());

                config.AddMap(new CustomerMap());

                config.ForDommel();
            });
        }
    }
    
}
