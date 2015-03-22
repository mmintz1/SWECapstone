using System;
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

        public ActionResult Cart()
        {
            return View();
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
