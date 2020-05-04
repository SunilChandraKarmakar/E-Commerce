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
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _iCategoryManager;

        public CategoryController(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
                return View(_iCategoryManager.GetAll().Where(c => c.Categorye == null).OrderByDescending(c=>c.Id));
            
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
                return View();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult AddCategory(Category aCategoryDetails)
        {
            if(ModelState.IsValid)
            {
                bool isAdd = _iCategoryManager.Add(aCategoryDetails);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    return ViewBag.ErrorMessage = "Category add has been failed! Try again.";
            }                                                                                
            
            return View(aCategoryDetails);
        }

        [HttpGet]
        public IActionResult AddSubCategory(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category aCategoryInfo = _iCategoryManager.GetById(id);

                if (aCategoryInfo == null)
                    NotFound();

                return View(aCategoryInfo);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult AddSubCategory(Category aCategoryInfo, string subCategory)
        {
            if(ModelState.IsValid)
            {
                Category addSubCategory = new Category
                {                       
                    Name = subCategory,
                    CategoryId = aCategoryInfo.Id,
                    Status = aCategoryInfo.Status,
                };

                bool isSave = _iCategoryManager.Add(addSubCategory);

                if (isSave)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Sub Category add failed! Try again.";
            }

            return View(aCategoryInfo);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                Category findCategory = _iCategoryManager.GetById(id);
                bool isDelete = _iCategoryManager.Remove(findCategory);

                if (isDelete)
                    return RedirectToAction("Index");

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult EditCategory(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                Category aCategoryDetails = _iCategoryManager.GetById(id);

                if (aCategoryDetails == null)
                    return NotFound();

                return View(aCategoryDetails);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult EditCategory(Category aCategory)
        {
            if(ModelState.IsValid)
            {
                bool isUpdate = _iCategoryManager.Update(aCategory);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Category update has benn failed! Try again.";
            }

            return View(aCategory);
        }
    }
}