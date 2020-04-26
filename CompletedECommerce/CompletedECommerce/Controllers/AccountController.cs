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
    public class AccountController : Controller
    {
        private readonly IAccountManager _iAccountManager;

        public AccountController(IAccountManager iAccountManager)
        {
            _iAccountManager = iAccountManager;
        }

        private int LoginAdminId()
        {
            string loginAdminId = HttpContext.Session.GetString("AdminId");
            int convertIntLoginAdminId = Convert.ToInt32(loginAdminId);
            return convertIntLoginAdminId;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                Account loginAdminAccountInfo = _iAccountManager.GetById(LoginAdminId());
                return View(loginAdminAccountInfo);
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Profile(Account aAccountDetails)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iAccountManager.Update(aAccountDetails);

                if (isUpdate == true)
                {
                    ViewBag.Message = "Update Successfull.";
                    Account updateAccountInfo = _iAccountManager.GetById(aAccountDetails.Id);
                    return View(updateAccountInfo);
                }
                else
                    ViewBag.Message = "Update has been failed! Please try again.";
            }
            return View(aAccountDetails);
        }
    }
}