﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net14.Web.Services;

namespace Net14.Web.Controllers
{
    public class SocialCurrencyController : Controller
    {
        private CurrencyService _currencyService;
        public SocialCurrencyController(CurrencyService currencyService) 
        {
            _currencyService = currencyService;
        }
        [HttpGet]
        public IActionResult GetCurrency()
        {
            var model = _currencyService.GetCurrency("USD");
            return View(model);
        }
    }
}
