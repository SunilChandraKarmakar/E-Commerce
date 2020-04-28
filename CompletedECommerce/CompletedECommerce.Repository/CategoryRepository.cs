using CompletedECommerce.Repository.Base;
using CompletedECommerce.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompletedECommerce.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository 
    {
        public override ICollection<Category> GetAll()
        {
            ICollection<Category> categoryList = ecommerceDb.Categories
                                                .Include(c => c.Categories)
                                                .Include(c=> c.Categorye)
                                                .ToList();
            return categoryList;
        }
    }
}
