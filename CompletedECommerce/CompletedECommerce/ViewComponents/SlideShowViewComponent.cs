using CompletedECommerce.Manager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.ViewComponents
{
    public class SlideShowViewComponent : ViewComponent 
    {
        private readonly ISlideShowManager _iSlideShowManager;

        public SlideShowViewComponent(ISlideShowManager iSlideShowManager)
        {
            _iSlideShowManager = iSlideShowManager;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<SlideShow> slideShowList = _iSlideShowManager.GetAll().Where(s => s.Status == true).ToList();
            return View(slideShowList);
        }
    }
}
