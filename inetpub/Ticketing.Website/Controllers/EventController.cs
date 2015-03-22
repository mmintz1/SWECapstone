using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Website.Controllers
{
    public class EventController : Controller
    {
        public ActionResult EventDetails(int id)
        {
            var mediator = new TicketMediator();
            var model = mediator.GetEvent(id);
            model.Performances = new List<PerformanceVM>();
            model.Performances = mediator.GetPerformances(id);
            return View(model);
        }

        public ActionResult BuyTickets()
        {
            var mediator = new TicketMediator();
            var model = mediator.GetAllPerformances();
            return View(model);
        }

        public ActionResult EventList()
        {
            var mediator = new TicketMediator();
            List<EventVM> events = mediator.GetEvents();
            return View(events);
        }

        public ActionResult AddToCart(int performanceId, int quantity)
        {
            return Redirect("/Checkout/Cart");
        }

    }
}
