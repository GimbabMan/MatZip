using System.Collections.Generic;
using System.Linq;

namespace ThirdProject.Data
{
    public class CodeCategoryData :EntityData<CodeCategory>
    {
        public List<CodeCategory> Get(int codeCategoryId)
        {
            MatZipEntities context = CreateContext();
            var query = from x in context.CodeCategories
                        where x.CodeCategoryId == codeCategoryId
                        select x;

            return query.ToList();
        }
    }
}
