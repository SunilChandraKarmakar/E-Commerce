using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace CompletedECommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly ICategoryManager _iCategoryManager;

        public ProductController(IProductManager iProductManager, ICategoryManager iCategoryManager)
        {
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
                return View(_iProductManager.GetAll());

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
    }
}