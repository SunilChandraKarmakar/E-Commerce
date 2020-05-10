using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CompletedECommerce.Controllers
{
    public class ClinteDeshboardController : Controller
    {
        private readonly IAccountManager _iAccountManager;

        public ClinteDeshboardController(IAccountManager iAccountManager)
        {
            _iAccountManager = iAccountManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
                return View();
            else
                return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                string customerId = HttpContext.Session.GetString("CustomerId");
                int conIntCustomerId = Convert.ToInt32(customerId);
                Account loginCustomerInfo = _iAccountManager.GetById(conIntCustomerId);
                return View(loginCustomerInfo);
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpPost]
        public IActionResult Profile(Account customerProfile)
        {
            customerProfile.Status = true;

            if(ModelState.IsValid)
            {
                bool isUpdate = _iAccountManager.Update(customerProfile);

                if (isUpdate)
                {
                    ViewBag.ErrorMessage = "Customer profile has been updated.";
                    return RedirectToAction("Profile");
                }
                    
                else
                {
                    ViewBag.ErrorMessage = "Customer profile update has been failed! Try again";
                    return View(customerProfile);
                }
            }

            ViewBag.ErrorMessage = "Customer profile update has been failed! Try again";
            return View(customerProfile);
        }
    }
}