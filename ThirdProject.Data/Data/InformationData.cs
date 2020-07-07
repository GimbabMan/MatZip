using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class InformationData:EntityData<Information>
    {
        public List<Information> Get(int restaurantId)
        {
            MatZipEntities context = CreateContext();
            var query = from x in context.Information
                        where x.RestaurantId == restaurantId
                        select x;

            return query.ToList();
        }
    }
}
