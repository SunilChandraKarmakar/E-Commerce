﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompletedECommerce.ViewComponents
{
    public class CartTopViewComponent : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
