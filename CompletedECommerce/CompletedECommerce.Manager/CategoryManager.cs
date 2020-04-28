using CompletedECommerce.Manager.Base;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Repository.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompletedECommerce.Manager
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager 
    {
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryManager(ICategoryRepository iCategoryRepository) : base(iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }

        public override ICollection<Category> GetAll()
        {
            return _iCategoryRepository.GetAll();
        }
    }
}
