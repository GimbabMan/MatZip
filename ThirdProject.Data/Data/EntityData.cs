using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdProject.Data
{
    public class EntityData<T> where T:class
    {
        protected MatZipEntities CreateContext()
        {
            MatZipEntities context = new MatZipEntities();
            context.Configuration.ProxyCreationEnabled = false;
            context.Database.Log = x => Console.WriteLine(x);
            return context;
        }
        public void Insert(T entity)
        {
            MatZipEntities context = CreateContext();
            context.Entry(entity).State = EntityState.Added;

            context.SaveChanges();
        }
        public void Update(T entity)
        {
            MatZipEntities context = CreateContext();
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            MatZipEntities context = CreateContext();
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public List<T> GetAll()
        {
            MatZipEntities context = CreateContext();
            return context.Set<T>().ToList();
        }

    }
}
