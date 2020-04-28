using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.ViewComponents
{
    //[ViewComponent(Name = "NamNai")]
    public class CategoryViewComponent : ViewComponent 
    {
        private readonly ICategoryManager _iCategoryManager;

        public CategoryViewComponent(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Category> categoryList = _iCategoryManager.GetAll()
                                          .Where(c => c.Categorye == null && c.Status == true).ToList();
            return View(categoryList);
        }
    }
}
