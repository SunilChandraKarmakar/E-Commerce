using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompletedECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _iProductManager;

        public ProductController(IProductManager iProductManager)
        {
            _iProductManager = iProductManager;
        }

        public IActionResult Index()
        {
            return View(_iProductManager.GetAll());
        }
    }
}