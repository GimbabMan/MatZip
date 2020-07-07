using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class MenuData:EntityData<Menu>
    {
        public List<Menu> Get(int restaurantId)
        {
            MatZipEntities context = CreateContext();
            var query = from x in context.Menus
                        where x.RestaurantId == restaurantId
                        select x;

            return query.ToList();
        }
    }
}
