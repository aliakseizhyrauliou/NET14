﻿using Microsoft.AspNetCore.Mvc;
using Net14.Web.Models.Shulte;
using System;
using System.Collections.Generic;

namespace Net14.Web.Controllers
{
    public class ShulteController : Controller
    {
        public IActionResult Main()
        {
            var number = new RandomNumberViewModel();
            number.Today = (int)DateTime.Now.DayOfWeek;

            return View(number);
           
        }
    }
}
