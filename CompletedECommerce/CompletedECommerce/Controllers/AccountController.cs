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
        private readonly IInvoiceManager _iInvoiceManager;
        private readonly IInvoiceDetailsManager _iInvoiceDetailsManager;

        public AccountController(IAccountManager iAccountManager,
                                IRoleAccountManager iRoleAccountManager, IInvoiceManager iInvoiceManager,
                                IInvoiceDetailsManager iInvoiceDetailsManager)
        {
            _iAccountManager = iAccountManager;
            _iRoleAccountManager = iRoleAccountManager;
            _iInvoiceManager = iInvoiceManager;
            _iInvoiceDetailsManager = iInvoiceDetailsManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<RoleAccount> customerList = _iRoleAccountManager.GetAll()
                                                        .Where(ra => ra.RoleId == 2 && ra.Status == true)
                                                        .ToList();
                return View(customerList);
            }

            return RedirectToAction("Index", "Login");
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
                    return RedirectToAction("Index", "Home");
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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                RoleAccount getRoleAccount = _iRoleAccountManager.GetById(id);
                Account getSelectedCustomer = _iAccountManager.GetAll()
                                              .Where(a => a.Id == getRoleAccount.AccountId).FirstOrDefault();
                if (getRoleAccount == null || getSelectedCustomer == null)
                    return NotFound();

                return View(getSelectedCustomer);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Edit(Account accountDetails)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iAccountManager.Update(accountDetails);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Customer account update failed! Try again";
                    return View(accountDetails);
                }
            }

            ViewBag.ErrorMessage = "Customer account update failed! Try again";
            return View(accountDetails);
        }

        [HttpGet]
        public IActionResult InvoiceHistory()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                string loginCustomerId = HttpContext.Session.GetString("CustomerId");
                ICollection<Invoice> customerInvoices = _iInvoiceManager.GetAll()
                                                .Where(i => i.AccountId == 
                                                       Convert.ToInt32(loginCustomerId)).ToList();
                return View(customerInvoices);
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                ICollection<InvoiceDetails> customerInvoiceDetails = _iInvoiceDetailsManager.GetAll()
                                                                     .Where(ide => ide.InvoiceId == id)
                                                                     .ToList();
                return View(customerInvoiceDetails);
            }

            return RedirectToAction("CustomerLogin", "Login");
        }
    }    
}