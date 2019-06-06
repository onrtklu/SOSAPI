using Dommel;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.RestaurantDal
{
    public class RestaurantService : DapperGenericRepository<Restaurant>, IRestaurantService
    {
        public RestaurantService(IDbTransaction transaction) : base(transaction) { }

        public Restaurant GetRestaurant(int id)
        {
            var item = _connection.Get<Restaurant, RestaurantDetail, Restaurant>(id, (restaurant, detail) =>
            {
                restaurant.RestaurantDetail = detail;
                //restaurant.RestaurantPicture.Add(picture);
                return restaurant;
            });

            return item;
        }
    }
}
