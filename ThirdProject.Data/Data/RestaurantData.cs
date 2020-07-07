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
    }
}
