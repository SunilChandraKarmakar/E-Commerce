using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompletedECommerce.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IInvoiceManager _iInvoiceManager;
        private readonly IProductManager _iProductManager;
        private readonly IRoleAccountManager _iRoleAccountManager;
        private readonly ICategoryManager _iCategoryManager;

        public DashboardController(IInvoiceManager iInvoiceManager, IProductManager iProductManager,
                                    IRoleAccountManager iRoleAccountManager, 
                                    ICategoryManager iCategoryManager)
        {
            _iInvoiceManager = iInvoiceManager;
            _iProductManager = iProductManager;
            _iRoleAccountManager = iRoleAccountManager;
            _iCategoryManager = iCategoryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.NewOrder = _iInvoiceManager.GetAll()
                                   .Where(i => i.Status == false).ToList();
                ViewBag.TotalProducts = _iProductManager.GetAll();
                ViewBag.TotalCustomer = _iRoleAccountManager.GetAll().
                                        Where(ra => ra.RoleId == 2).ToList();
                ViewBag.TotalCategory = _iCategoryManager.GetAll()
                                        .Where(c => c.Categorye == null).ToList();
                return View();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}