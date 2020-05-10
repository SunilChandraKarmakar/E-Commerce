using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Views.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CompletedECommerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountManager _iAccountManager;
        private readonly IRoleManager _iRoleManager;
        private readonly IRoleAccountManager _iRoleAccountManager;

        public LoginController(IAccountManager iAccountManager, 
                                IRoleAccountManager iRoleAccountManager, IRoleManager iRoleManager)
        {
            _iAccountManager = iAccountManager;
            _iRoleAccountManager = iRoleAccountManager;
            _iRoleManager = iRoleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login loginInfo)
        {
            if(ModelState.IsValid)
            {
                Account loginAccountInfo = _iAccountManager.GetAll()
                                           .Where(a => a.Username == loginInfo.Username 
                                                  && a.Password == loginInfo.Password && a.Status == true)
                                           .FirstOrDefault();

                if(loginAccountInfo == null)
                {
                    ViewBag.ErrorMessage = "Invalid Username and Password! Try again.";
                    return View();
                }

                Role checkRole = _iRoleManager.GetAll().Where(r => r.Id == 1).FirstOrDefault();
                RoleAccount checkRoleAndAccount = _iRoleAccountManager.GetAll()
                                           .Where(cra => cra.RoleId == checkRole.Id
                                                    && cra.AccountId == loginAccountInfo.Id && cra.Status == true)
                                           .FirstOrDefault();

                if (checkRoleAndAccount != null)
                {
                    HttpContext.Session.SetString("AdminId", loginAccountInfo.Id.ToString());
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid Username and Password! Try again.";
                    return View();
                }
            }
            return View(loginInfo);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CustomerLogin(string username, string password)
        {
            if (ModelState.IsValid)
            {
                Account loginCustomerInfo = _iAccountManager.GetAll()
                                            .Where(a => a.Username == username
                                            && a.Password == password
                                            && a.Status == true).FirstOrDefault();

                if (loginCustomerInfo == null)
                {
                    ViewBag.ErrorMessage = "Username and password not match! Try again.";
                    return View("CustomerLogin");
                }

                RoleAccount aRoleAccountInfo = _iRoleAccountManager.GetAll()
                                               .Where(ra => ra.RoleId == 2
                                                      && ra.AccountId == loginCustomerInfo.Id
                                                      && ra.Status == true).FirstOrDefault();

                if (aRoleAccountInfo != null)
                {
                    HttpContext.Session.SetString("CustomerId", loginCustomerInfo.Id.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Username and password not match! Try again.";
                    return View("CustomerLogin");
                }

            }

            ViewBag.ErrorMessage = "Username and password are not match! Try again";
            return View("CustomerLogin");
        }
    }
}