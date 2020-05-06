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
        private readonly IProductManager _iProductManager;

        public CategoryViewComponent(ICategoryManager iCategoryManager, IProductManager iProductManager)
        {
            _iCategoryManager = iCategoryManager;
            _iProductManager = iProductManager;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Category> categoryList = _iCategoryManager.GetAll()
                                          .Where(c => c.Categorye == null && c.Status == true).ToList();
            ViewBag.Products = _iProductManager.GetAll();
            return View(categoryList);
        }
    }
}
