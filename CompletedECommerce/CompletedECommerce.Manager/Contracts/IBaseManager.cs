using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager.Contracts
{
    public interface IBaseManager<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetById(int? id);
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Remove(T entity);
    }
}
