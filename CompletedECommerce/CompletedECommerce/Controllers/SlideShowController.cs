using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CompletedECommerce.Controllers
{
    public class SlideShowController : Controller
    {
        private readonly ISlideShowManager _iSlideShowManager;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public SlideShowController(ISlideShowManager iSlideShowManager, IHostingEnvironment iHostingEnvironment)
        {
            _iSlideShowManager = iSlideShowManager;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                ICollection<SlideShow> slideShowList = _iSlideShowManager.GetAll();
                return View(slideShowList);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Add()
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Add(SlideShow aSlideShow, IFormFile photo)
        {                      
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                      + "/SlideShow", Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aSlideShow.Photo = "SlideShow/" + photo.FileName;
                }

                if (photo == null)
                    aSlideShow.Photo = "SlideShow/NoImageFound.png";

                bool isAdd = _iSlideShowManager.Add(aSlideShow);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Slide Show save has been failed!";
            }

            return View(aSlideShow);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                if (id == null)
                    return NotFound();

                SlideShow aSlideShowInfo = _iSlideShowManager.GetById(id);

                if (aSlideShowInfo == null)
                    return NotFound();

                return View(aSlideShowInfo);
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Edit(SlideShow aSlideShow, IFormFile photo, string pto)
        {
            if(ModelState.IsValid)
            {
                if (photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                                                      + "/SlideShow", Path.GetFileName(photo.FileName));
                    photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    aSlideShow.Photo = "SlideShow/" + photo.FileName;
                }

                if (photo == null)
                    aSlideShow.Photo = pto;

                bool isUpdate = _iSlideShowManager.Update(aSlideShow);

                if (isUpdate)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Slide Show update failed! Try again.";
            }

            return View(aSlideShow);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(HttpContext.Session.GetString("AdminId") != null)
            {
                SlideShow aSlideShowInfo = _iSlideShowManager.GetById(id);

                bool isDelete = _iSlideShowManager.Remove(aSlideShowInfo);

                if (isDelete)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Slide Show delete failed! Try again.";
            }

            return RedirectToAction("Index", "Login");
        }
    }
}