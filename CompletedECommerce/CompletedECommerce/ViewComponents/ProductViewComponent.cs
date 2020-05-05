using CompletedECommerce.Databse;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IProductManager _iProductManager;

        public ProductViewComponent(IProductManager iProductManager)
        {
            _iProductManager = iProductManager;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Product> products = _iProductManager.GetAll().OrderByDescending(p=>p.Id)
                                            .Where(p => p.Status == true && p.Featured == false).Take(2).ToList();
            return View(products);
        }
    }
}
