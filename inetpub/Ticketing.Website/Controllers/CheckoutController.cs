﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Models.Cart;

namespace Ticketing.Website.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cart()
        {
            var model = new CartVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult Cart(CartVM cart)
        {
            return View(cart);
        }

        [HttpGet]
        public ActionResult Review()
        {
            var model = new PaymentVM();
            return View("~/Views/Checkout/Review.cshtml", model);
        }

        [HttpPost]
        public ActionResult Review(PaymentVM model)
        {
            return View("~/Views/Checkout/Review.cshtml", model);
        }
    }
}
