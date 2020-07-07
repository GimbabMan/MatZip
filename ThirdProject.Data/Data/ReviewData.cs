using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class ReviewData:EntityData<Review>
    {
        public List<Review> Get(int reviewId)
        {
            MatZipEntities context = CreateContext();
            var query = from x in context.Reviews
                        where x.ReviewId == reviewId
                        select x;

            return query.ToList();
        }
    }
}
