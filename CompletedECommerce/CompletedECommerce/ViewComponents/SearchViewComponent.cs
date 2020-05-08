using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<SelectListItem> categorySelectList = categoryList.Select(c => new SelectListItem
                                                      {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                      }).ToList();
            return View(categorySelectList);
        }
    }
}
