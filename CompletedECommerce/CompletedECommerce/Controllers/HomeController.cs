using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CompletedECommerce.Models;
using CompletedECommerce.Manager.Contracts;
using Models;

namespace CompletedECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductManager _iProductManager;

        public HomeController(ILogger<HomeController> logger, IProductManager iProductManager)
        {
            _logger = logger;
            _iProductManager = iProductManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FeaturedProducts = _iProductManager.GetAll()
                                                    .Where(fp => fp.Status == true && fp.Featured == true).ToList();
            ViewBag.LatestProducts = _iProductManager.GetAll()
                                    .Where(lp => lp.Status == true && lp.Featured == false).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
