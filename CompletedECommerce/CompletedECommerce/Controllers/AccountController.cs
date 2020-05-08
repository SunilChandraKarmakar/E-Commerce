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
        private readonly IRoleAccountManager _iRoleAccountManager;

        public AccountController(IAccountManager iAccountManager,IRoleAccountManager iRoleAccountManager)
        {
            _iAccountManager = iAccountManager;
            _iRoleAccountManager = iRoleAccountManager;
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account aAccountInfo)
        {
            aAccountInfo.Status = true;
            
            if(ModelState.IsValid)
            {
                bool isSaveAccount = _iAccountManager.Add(aAccountInfo);
                Account lastAddAccountInfo = _iAccountManager.GetAll().LastOrDefault();
                RoleAccount initialRoleAccount = new RoleAccount()
                {
                    RoleId = 2,
                    AccountId = lastAddAccountInfo.Id,
                    Status = true
                };

                bool isSaveRoleAccount = _iRoleAccountManager.Add(initialRoleAccount);

                if(isSaveAccount == true && isSaveRoleAccount == true)
                    return RedirectToAction("Index", "Login");
                else
                {
                    ViewBag.ErrorMessage = "Registration has been failed! Try again.";
                    return View(aAccountInfo);
                }
            }

            return View(aAccountInfo);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public JsonResult ExistUserName(string userName)
        {
            Account aAccountInfo = _iAccountManager.GetAll()
                                   .Where(a => a.Username == userName).FirstOrDefault();
            if (aAccountInfo != null)
                return Json(1);
            else
                return Json(0);
        }

        [HttpGet]
        [Route("api/[controller]/[action]")]
        public JsonResult ExistEmail(string email)
        {
            Account aAccountInfo = _iAccountManager.GetAll()
                                   .Where(a => a.Email == email).FirstOrDefault();
            if (aAccountInfo != null)
                return Json(1);
            else
                return Json(0);
        }
    }
}