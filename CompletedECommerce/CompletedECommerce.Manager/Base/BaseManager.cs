using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager.Base
{
    public abstract class BaseManager<T> : IBaseManager<T> where T : class
    {
        private readonly IBaseRepository<T> _iBaseRepository;

        public BaseManager(IBaseRepository<T> iBaseRepository)
        {
            _iBaseRepository = iBaseRepository;
        }

        public virtual ICollection<T> GetAll()
        {
            return _iBaseRepository.GetAll();
        }

        public virtual T GetById(int? id)
        {
            return _iBaseRepository.GetById(id);
        }

        public bool Add(T entity)
        {
            return _iBaseRepository.Add(entity);
        }

        public bool Update(T entity)
        {
            return _iBaseRepository.Update(entity);
        }

        public bool Remove(T entity)
        {
            return _iBaseRepository.Remove(entity);
        }         
    }
}
