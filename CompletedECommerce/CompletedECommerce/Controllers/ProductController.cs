﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using X.PagedList;

namespace CompletedECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IInvoiceDetailsManager _invoiceDetailsManager;

        public ProductController(IProductManager iProductManager, ICategoryManager iCategoryManager,
                                IProductPhotoManager iProductPhotoManager, IInvoiceDetailsManager invoiceDetailsManager)
        {
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iProductPhotoManager = iProductPhotoManager;
            _invoiceDetailsManager = invoiceDetailsManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.InvoiceDetailsList = _invoiceDetailsManager.GetAll();
                return View(_iProductManager.GetAll());
            }
                

            return RedirectToAction("Index", "Login");
        }

        private List<SelectListItem> CategoryList()
        {
            List<SelectListItem> categoryList = _iCategoryManager.GetAll()
                                                .Select(c => new SelectListItem
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.Name
                                                }).ToList();
            return categoryList;
        }

        [HttpGet]
        public IActionResult Create()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.CategoryList = CategoryList();
                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Create(Product aProduct)
        {
            if(ModelState.IsValid)
            {
                bool isCreate = _iProductManager.Add(aProduct);

                if (isCreate)
                    return RedirectToActionPermanent("Index");
                else
                    ViewBag.ErrorMessage = "Product has been saved failed! Try again.";
            }

            ViewBag.CategoryList = CategoryList();
            return View(aProduct);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Product aProductDetails = _iProductManager.GetById(id);

                if (aProductDetails == null)
                    return NotFound();

                ViewBag.CategoryList = CategoryList();
                return View(aProductDetails);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Edit(Product aProductInfo)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iProductManager.Update(aProductInfo);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "Product update has been failed! Try again";
                    return View(aProductInfo);
                }
            }

            ViewBag.CategoryList = CategoryList();
            return View(aProductInfo);
        }

        [HttpGet]
        public IActionResult AllProductImage(int id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<ProductPhoto> productPhotos = _iProductPhotoManager.GetAll()
                                                      .Where(ph => ph.ProductId == id).ToList();
                return View(productPhotos);
            }

            return RedirectToAction("Index", "Login");
                                                      
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Product aProductDetails = _iProductManager.GetById(id);

                if (aProductDetails == null)
                    return NotFound();

                bool isRemove = _iProductManager.Remove(aProductDetails);

                if (isRemove)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Product delete has been failed! Try again";
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
                return NotFound();

            Product selectedProductDetails = _iProductManager.GetById(id);

            if (selectedProductDetails == null)
                return NotFound();

            ICollection<ProductPhoto> aProductPhotoList = _iProductPhotoManager.GetAll()
                                                          .Where(ph => ph.ProductId == id).ToList();
            ProductPhoto productFeaturedPhoto = aProductPhotoList
                                                .Where(ph => ph.Status == true && ph.Featured == true)
                                                .FirstOrDefault();
            ViewBag.ProductFeaturedPhotoName = productFeaturedPhoto == null ? "SlideShow/NoImageFound.png" : productFeaturedPhoto.Photo;
            ViewBag.ProductPhotoList = aProductPhotoList;
            ViewBag.RelatedProduct = _iProductManager.GetAll()
                                    .Where(p => p.CategoryId == selectedProductDetails.CategoryId 
                                           && p.Id != selectedProductDetails.Id && p.Status == true).ToList();
            return View(selectedProductDetails);
        }

        [HttpGet]
        public IActionResult GetProductByCategoryId(int? id, int? page)
        {
            if (id == null)
                return NotFound();

            Category selectedCategoryInfo = _iCategoryManager.GetById(id);
            IPagedList<Product> products = _iProductManager.GetAll()
                                            .Where(p => p.CategoryId == id && p.Status == true)
                                            .ToPagedList(page ?? 1, 6);
            ViewBag.SelectedCategoryInfo = selectedCategoryInfo;
            return View(products);
        }

        [HttpGet]
        public IActionResult SearchProductByName(string productName, int? page)
        {
            string productNameCapitalize = String.Concat(productName.Select((currentChar, index)
                                           => index == 0 ? Char.ToUpper(currentChar) : currentChar));
            IPagedList<Product> searchProducts = _iProductManager.GetAll()
                                                  .Where(p => p.Name.Contains(productNameCapitalize)
                                                  && p.Status == true).ToPagedList(page ?? 1, 6);
            ViewBag.ProductName = productName;
            return View(searchProducts);
        }

        [HttpGet]
        public IActionResult SearchProductByPrice(int startingPrice, int endingPrice)
        {
            if(ModelState.IsValid)
            {
                ICollection<Product> searchProductByPrice = _iProductManager.GetAll()
                    .Where(p => p.Price >= startingPrice && p.Price <= endingPrice).ToList();
                return View(searchProductByPrice);
            }

            return BadRequest();
        }
    }
}