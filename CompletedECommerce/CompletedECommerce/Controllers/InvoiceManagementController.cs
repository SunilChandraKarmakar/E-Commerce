using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CompletedECommerce.Controllers
{
    public class InvoiceManagementController : Controller
    {
        private readonly IInvoiceManager _iInvoiceManager;
        private readonly IInvoiceDetailsManager _iInvoiceDetailsManager;
        private readonly IAccountManager _iAccountManager;

        public InvoiceManagementController(IInvoiceManager iInvoiceManager,
                                            IInvoiceDetailsManager iInvoiceDetailsManager,
                                            IAccountManager iAccountManager)
        {
            _iInvoiceManager = iInvoiceManager;
            _iInvoiceDetailsManager = iInvoiceDetailsManager;
            _iAccountManager = iAccountManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<Invoice> customerInvoices = _iInvoiceManager.GetAll();
                return View(customerInvoices);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Invoice getInvoiceInfoById = _iInvoiceManager.GetById(id);
                Account getAccountInfoByInvoiceAccountId = _iAccountManager.GetAll()
                                                           .Where(a => a.Id == getInvoiceInfoById.AccountId)
                                                           .FirstOrDefault();

                if (getInvoiceInfoById == null)
                    return NotFound();

                ICollection<InvoiceDetails> customerInvoiceDetails = _iInvoiceDetailsManager.GetAll()
                                                                      .Where(ind => ind.InvoiceId == id)
                                                                      .ToList();
                ViewBag.AccountInfo = getAccountInfoByInvoiceAccountId;
                ViewBag.InvoiceInfo = getInvoiceInfoById;
                return View(customerInvoiceDetails);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult SubmitPayment(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Invoice invoiceInfo = _iInvoiceManager.GetById(id);

                if (invoiceInfo == null)
                    return NotFound();

                invoiceInfo.Status = true;
                bool isUpdate = _iInvoiceManager.Update(invoiceInfo);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    return NotFound();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}