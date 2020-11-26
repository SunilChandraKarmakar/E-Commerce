using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Views.ModelView;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CompletedECommerce.Controllers
{
    public class ProductPhotoController : Controller
    {
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IProductManager _iProductManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public ProductPhotoController(IProductPhotoManager iProductPhotoManager, IProductManager iProductManager,
                                      IHostingEnvironment iHostingEnvironment)
        {
            _iProductPhotoManager = iProductPhotoManager;
            _iProductManager = iProductManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ViewBag.ProductId = id; 
                return View();   
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Create(ProductPhotoModelView aProductPhotoModelViewInfo, IFormFile photo)
        {
            if(ModelState.IsValid)
            {   
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                      + "/productphotos", Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aProductPhotoModelViewInfo.Photo = "productphotos/" + photo.FileName;
                }

                if (photo == null)
                    aProductPhotoModelViewInfo.Photo = "SlideShow/NoImageFound.png";

                ProductPhoto aProductInfo = new ProductPhoto()
                {
                    ProductId = aProductPhotoModelViewInfo.ProductId,
                    Photo = aProductPhotoModelViewInfo.Photo,
                    Status = aProductPhotoModelViewInfo.Status,
                    Featured = aProductPhotoModelViewInfo.Featured
                };

                bool isCreate = _iProductPhotoManager.Add(aProductInfo);

                if (isCreate)
                    return RedirectToAction("AllProductImage", "Product", new {id = aProductPhotoModelViewInfo.ProductId });
                else
                {
                    ViewBag.ErrorMessage = "Product picture save failed! Try again.";
                    return View(aProductPhotoModelViewInfo);
                }
            }

            return View(aProductPhotoModelViewInfo);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ProductPhoto aProductPhotoInfo = _iProductPhotoManager.GetById(id);

                if (aProductPhotoInfo == null)
                    return NotFound();

                return View(aProductPhotoInfo);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Edit(ProductPhoto aProductPhotoInfo, IFormFile photo, string pto)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                      + "/productphotos", Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aProductPhotoInfo.Photo = "productphotos/" + photo.FileName;
                }

                if (photo == null)
                    aProductPhotoInfo.Photo = pto;

                bool isUpdate = _iProductPhotoManager.Update(aProductPhotoInfo);

                if (isUpdate)
                    return RedirectToAction("AllProductImage", "Product", new { id = aProductPhotoInfo.ProductId });
                else
                {
                    ViewBag.ErrorMessage = "Product Photo update has been failed! Try again.";
                    return View(aProductPhotoInfo);
                }
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

                ProductPhoto aProductPhotoInfo = _iProductPhotoManager.GetById(id);
                int productId = aProductPhotoInfo.ProductId;

                if (aProductPhotoInfo == null)
                    return NotFound();

                bool isRemove = _iProductPhotoManager.Remove(aProductPhotoInfo);

                if (isRemove)
                    return RedirectToAction("AllProductImage", "Product", new { id = productId });
                else
                    ViewBag.ErrorMessage = "Product photo remove has been failed! Try again.";
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult CreateFeatured(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                ProductPhoto selectedProductPhoto = _iProductPhotoManager.GetById(id);

                ICollection<ProductPhoto> productPhotosByCategoryId = _iProductPhotoManager.GetAll()
                                                                      .Where(ph => ph.ProductId 
                                                                                == selectedProductPhoto.ProductId)
                                                                      .ToList();
                bool isUpdateSelectedFeaturedProductPhoto = false;
                bool isUpdateCreateFeaturedProductPhoto = false;
                ProductPhoto selectedFeaturedProductPhoto = new ProductPhoto();

                if (productPhotosByCategoryId.Count == 1)
                    selectedProductPhoto.Featured = true;
                else
                {
                    selectedFeaturedProductPhoto = productPhotosByCategoryId
                                                           .Where(ph => ph.Featured == true).FirstOrDefault();
                    selectedFeaturedProductPhoto.Featured = false;
                    selectedProductPhoto.Featured = true;
                    isUpdateCreateFeaturedProductPhoto = _iProductPhotoManager.Update(selectedFeaturedProductPhoto);
                }

                isUpdateSelectedFeaturedProductPhoto = _iProductPhotoManager.Update(selectedProductPhoto);                

                if (isUpdateCreateFeaturedProductPhoto == true || isUpdateSelectedFeaturedProductPhoto == true)
                    return RedirectToAction("AllProductImage", "Product", new { id = selectedProductPhoto.ProductId });
                else
                {
                    ViewBag.ErrorMessage = "Featured product photo create failed! Try again.";
                    return RedirectToAction("AllProductImage", "Product", new { id = selectedProductPhoto.ProductId });
                }                           
            }

            return RedirectToAction("Index", "Login");
        }
    }
}