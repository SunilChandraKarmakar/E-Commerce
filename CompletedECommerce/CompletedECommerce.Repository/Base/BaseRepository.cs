using CompletedECommerce.Databse;
using CompletedECommerce.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompletedECommerce.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected readonly ECommerceDb ecommerceDb;

        public BaseRepository()
        {
            ecommerceDb = new ECommerceDb();
        }           

        public virtual ICollection<T> GetAll()
        {
            return ecommerceDb.Set<T>().ToList(); 
        }

        public virtual T GetById(int? id)
        {
            return ecommerceDb.Set<T>().Find(id);
        }

        public bool Add(T entity)
        {
            ecommerceDb.Set<T>().Add(entity);
            return ecommerceDb.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            ecommerceDb.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return ecommerceDb.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            ecommerceDb.Set<T>().Remove(entity);
            return ecommerceDb.SaveChanges() > 0;
        }         
    }
}
