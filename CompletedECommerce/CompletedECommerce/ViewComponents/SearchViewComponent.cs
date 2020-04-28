using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.ViewComponents
{
    public class SearchViewComponent : ViewComponent 
    {
        private readonly ICategoryManager _iCategoryManager;

        public SearchViewComponent(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Category> categoryList = _iCategoryManager.GetAll()
                                                .Where(c => c.Categorye == null & c.Status == true).ToList();
            return View(categoryList);
        }
    }
}
