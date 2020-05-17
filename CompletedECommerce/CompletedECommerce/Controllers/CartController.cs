using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace CompletedECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly IInvoiceManager _iInvoiceManager;
        private readonly IInvoiceDetailsManager _iInvoiceDetailsManager;

        public CartController(IProductManager iProductManager, IInvoiceManager iInvoiceManager,
                                IInvoiceDetailsManager iInvoiceDetailsManager)
        {
            _iProductManager = iProductManager;
            _iInvoiceManager = iInvoiceManager;
            _iInvoiceDetailsManager = iInvoiceDetailsManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                List<Product> products = HttpContext.Session.Get<List<Product>>("AddProducts");
                
                if (products == null)
                    products = new List<Product>();
                
                return View(products);
            }

            return RedirectToAction("CustomerLogin", "Login");
        }    
        
        [HttpGet]
        public IActionResult AddProduct(int? id, int? quantity)
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                Product selectedProductInfo = _iProductManager.GetById(id);

                if (selectedProductInfo == null)
                    return NotFound();

                List<Product> addProducts = new List<Product>();
                addProducts = HttpContext.Session.Get<List<Product>>("AddProducts");

                if (addProducts == null)
                    addProducts = new List<Product>();

                Product existProduct = addProducts.Where(ap => ap.Id == id).FirstOrDefault();
                
                if(existProduct != null)
                {
                    addProducts.Remove(existProduct);

                    if (quantity == null)
                        existProduct.Quantity += 1;
                    else
                        existProduct.Quantity = existProduct.Quantity + (int)quantity;

                    addProducts.Add(existProduct);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }
                else
                {
                    if (quantity == null)
                        selectedProductInfo.Quantity = 1;
                    else
                        selectedProductInfo.Quantity = (int)quantity;

                    addProducts.Add(selectedProductInfo);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }                                                                      
              
                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpGet]
        public IActionResult Remove(int? id)
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                if (id == null)
                    return NotFound();

                List<Product> products = HttpContext.Session.Get<List<Product>>("AddProducts");
                Product existProduct = products.Where(p => p.Id == id).FirstOrDefault();
                products.Remove(existProduct);
                HttpContext.Session.Set("AddProducts", products);

                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpPost]
        public IActionResult Update(int[] quantity)
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {   
                List<Product> addProductList = HttpContext.Session.Get<List<Product>>("AddProducts");

                for (int i = 0; i < addProductList.Count(); i++)
                {
                    addProductList[i].Quantity = quantity[i];
                }

                HttpContext.Session.Set("AddProducts", addProductList);
                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                string loginCustomerId = HttpContext.Session.GetString("CustomerId");
                int conIntloginCustomerId = Convert.ToInt32(loginCustomerId);
                                
                Invoice customerInvoice = new Invoice()
                {
                    AccountId = conIntloginCustomerId,
                    Date = DateTime.Now.Date,
                    Name = "Order Invoice",
                    Status = false
                };
                                
                bool isSaveCustomerInvoice = _iInvoiceManager.Add(customerInvoice);
                bool isSaveCustomerInvoiceDetails = false;
                Invoice lastCustomerInvoice = _iInvoiceManager.GetAll().LastOrDefault();

                List<Product> addProducts = HttpContext.Session.Get<List<Product>>("AddProducts");
                foreach (Product product in addProducts)
                {
                    InvoiceDetails customerInvoiceDetails = new InvoiceDetails()
                    {
                        InvoiceId = lastCustomerInvoice.Id,
                        Price = product.Price,
                        ProductId = product.Id,
                        Quantity = product.Quantity
                    };

                    isSaveCustomerInvoiceDetails = _iInvoiceDetailsManager.Add(customerInvoiceDetails);
                }

                if(isSaveCustomerInvoice && isSaveCustomerInvoiceDetails)
                {
                    HttpContext.Session.Remove("AddProducts");
                    return RedirectToAction("Thanks");
                }
                else
                {
                    ViewBag.ErrorMessage = "Chack out is failed! Try Again";
                    return View("Index");
                }
            }

            return RedirectToAction("CustomerLogin", "Login");
        }

        [HttpGet]
        public IActionResult Thanks()
        {
            if(HttpContext.Session.GetString("CustomerId") != null)
            {
                return View();
            }

            return RedirectToAction("CustomerLogin", "Login");
        }
    }
}