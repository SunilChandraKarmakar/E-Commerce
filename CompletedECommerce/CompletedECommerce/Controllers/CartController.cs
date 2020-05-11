using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompletedECommerce.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
                return View();

            return RedirectToAction("CustomerLogin", "Login");
        }
    }
}