using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompletedECommerce.Controllers
{
    public class DashboardController : Controller
    {
       [HttpGet]
       public IActionResult Index()
       {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View();
            else
                return RedirectToAction("Index", "Login");
       }
    }
}