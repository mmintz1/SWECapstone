using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mediator = new TicketMediator();
            var model = mediator.GetUpcomingPerformances();

            return View("~/Views/Home/Index.cshtml", model);
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
