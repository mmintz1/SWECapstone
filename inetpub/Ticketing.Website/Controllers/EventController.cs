using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Cart;
using Ticketing.Framework.Models.Common;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Website.Controllers
{
    public class EventController : Controller
    {
        public ActionResult EventDetails(int id)
        {
            var mediator = new TicketMediator();
            var model = mediator.GetEvent(id);
            //model.Performances = new List<PerformanceVM>();
            //model.Performances = mediator.GetPerformances(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult BuyTickets()
        {
            var mediator = new TicketMediator();
            var model = new BuyTicketsVM();
            model.Performances = new List<PerformanceVM>();
            model.Performances = mediator.GetAllPerformances();

            model.Categories = new List<Category>();
            model.Categories = mediator.GetEventTypes();
            model.Events = new List<EventItem>();
            model.Events = mediator.GetEventItems();
            model.FromDate = DateTime.Today.ToString("MM/dd/yyyy");
            return View(model);
        }

        //[HttpPost]
        //public ActionResult BuyTickets(string FromDate, string ToDate)
        //{
        //    var mediator = new TicketMediator();
        //    var model = new BuyTicketsVM();
        //    model.Performances = new List<PerformanceVM>();
        //    model.Performances = mediator.GetAllPerformances();

        //    model.Categories = new List<Category>();
        //    model.Categories = mediator.GetEventTypes();
        //    model.Events = new List<EventItem>();
        //    model.Events = mediator.GetEventItems();
        //    model.FromDate = DateTime.Today.ToString("MM/dd/yyyy");
        //    return View(model);
        //}

        public ActionResult EventList()
        {
            var mediator = new TicketMediator();
            List<EventVM> events = mediator.GetActiveEvents();
            return View(events);
        }

        public ActionResult AddToCart(PerformanceVM model)
        {
            var mediator = new TicketMediator();
            CartVM cart = mediator.GetCart();
            cart.Performances.Add(model);
            return Redirect("/Checkout/Cart");
        }

        [HttpPost]
        public ActionResult BuyTickets(BuyTicketsVM model)
        {
            var mediator = new TicketMediator();
            model.Performances = new List<PerformanceVM>();
            var perfs = mediator.GetAllPerformances();
            var fromDate = DateTime.Parse(model.FromDate);
            var toDate = fromDate.AddYears(1);
            if (!string.IsNullOrEmpty(model.ToDate))
                toDate = DateTime.Parse(model.ToDate).AddHours(1);

            perfs = perfs.Where(p => DateTime.Parse(p.PerformanceDate) > fromDate && DateTime.Parse(p.PerformanceDate) < toDate).ToList();
            
            var selectedEventType = model.Events.Where(p => p.SelectedIndicator).Select(e => e.EventId);
            var selectedCategoryType = model.Categories.Where(p => p.SelectedIndicator).Select(e => e.CategoryId);

            if (selectedEventType.Count() > 0)
                perfs = perfs.Where(p => selectedEventType.Contains(p.EventId)).ToList();

            if (selectedCategoryType.Count() > 0 && (perfs != null && perfs.Count > 0))
                perfs = perfs.Where(p => selectedCategoryType.Contains(p.EventId)).ToList();


            model.Performances = perfs;
            return View(model);
        }

    }
}
