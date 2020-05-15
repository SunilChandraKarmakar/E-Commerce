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

        public CartController(IProductManager iProductManager)
        {
            _iProductManager = iProductManager;
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
        public IActionResult AddProduct(int? id)
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
                    existProduct.Quantity += 1;                     
                    addProducts.Add(existProduct);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }
                else
                {
                    selectedProductInfo.Quantity = 1;
                    addProducts.Add(selectedProductInfo);
                    HttpContext.Session.Set("AddProducts", addProducts);
                }                                                                      
              
                return RedirectToAction("Index");
            }

            return RedirectToAction("CustomerLogin", "Login");
        }
    }
}