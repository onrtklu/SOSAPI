using Dommel;
using SOS.Core.DataAccess.Dapper;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SOS.DataAccess.DapperDal.RestaurantDal
{
    public class RestaurantService : DapperGenericRepository<Restaurant>, IRestaurantService
    {
        public RestaurantService(IDbTransaction transaction) : base(transaction) { }

        public Restaurant GetRestaurant(int id)
        {
            var item = _connection.QueryMultiple("Restaurant.GetMenuRestaurant", 
                new { Id = id }, 
                _transaction, 
                commandType: CommandType.StoredProcedure);

            var restaurant = item.Read<Restaurant, RestaurantType, RestaurantDetail, Restaurant>((res, typ, det) => 
            {
                res.RestaurantType = typ;
                res.RestaurantDetail = det;
                return res;
            }).SingleOrDefault();
            
            if(restaurant != null)
                restaurant.RestaurantPicture = item.Read<RestaurantPicture>().ToList();

            return restaurant;
        }
    }
}
