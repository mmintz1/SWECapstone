using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Cart;
using Ticketing.Framework.Models.Ticket;

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
            var mediator = new TicketMediator();
            CartVM model = mediator.GetCart();

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

        [HttpPost]
        public ActionResult Remove(PerformanceVM perf)
        {
            var mediator = new TicketMediator();
            var cart = mediator.GetCart();
            var success = cart.Performances.RemoveAll(p => p.PerformanceId == perf.PerformanceId);
            return Redirect("/checkout/cart");
        }
    }
}
