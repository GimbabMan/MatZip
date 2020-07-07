using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class RestaurantData:EntityData<Restaurant>
    {
        public Restaurant Get(int restaurantId)
        {
            MatZipEntities context = CreateContext();
          
            return context.Restaurants.FirstOrDefault(x => x.RestaurantId == restaurantId);
        }

        public List<Restaurant> Get(decimal latitude, decimal longitude)
        {
            MatZipEntities context = CreateContext();

            var query = from x in context.Restaurants
                        where x.Latitude == latitude && x.Longitude == longitude
                        select x;

            return query.ToList();
        }
    }
}
