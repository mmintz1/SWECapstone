using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Website.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult EditEvent()
        {
            var mediator = new TicketMediator();
            var model =  mediator.GetEvent(0);
            
            ViewBag.PageTitle = "Edit Event";
            return View("~/Views/Admin/EventForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditEvent(EventVM model)
        {
            var mediator = new TicketMediator();
            var success = mediator.UpdateEvent(model);

            if (success)
                return Redirect("/");
            else
            {
                ViewBag.PageTitle = "Edit Event";
                ModelState.AddModelError("ErrorMessage", "Unable to update event. Please verify input.");
                return View("~/Views/Admin/EventForm.cshtml", model);
            }
        }

        [HttpGet]
        public ActionResult CreateEvent()
        {
            var model = new EventVM();
            ViewBag.PageTitle = "Create Event";
            return View("~/Views/Admin/EventForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateEvent(EventVM model)
        {
            var mediator = new TicketMediator();
            var success = mediator.CreateEvent(model);

            if (success)
                return Redirect("/");
            else
            {
                ViewBag.PageTitle = "Create Event";
                ModelState.AddModelError("ErrorMessage", "Unable to create event. Please verify input.");
                return View("~/Views/Admin/EventForm.cshtml", model);
            }
        }

        [HttpGet]
        public ActionResult EditPerformance()
        {
            var mediator = new TicketMediator();
            var model = mediator.GetPerformance(0);
            ViewBag.PageTitle = "Edit Performance";
            return View("~/Views/Admin/PerformanceForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditPerformance(PerformanceVM model)
        {
            var mediator = new TicketMediator();
            var success = mediator.UpdatePerformance(model);

            if (success)
                return Redirect("/");
            else
            {
                ViewBag.PageTitle = "Edit Performance";
                ModelState.AddModelError("ErrorMessage", "Unable to create event. Please verify input.");
                return View("~/Views/Admin/PerformanceForm.cshtml", model);
            }
        }

        [HttpGet]
        public ActionResult CreatePerformance()
        {
            var model = new PerformanceVM();
            ViewBag.PageTitle = "Create Performance";
            return View("~/Views/Admin/PerformanceForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreatePerformance(PerformanceVM model)
        {
            var mediator = new TicketMediator();
            var success = mediator.CreatePerformance(model);

            if (success)
                return Redirect("/");
            else
            {
                ViewBag.PageTitle = "Create Performance";
                ModelState.AddModelError("ErrorMessage", "Unable to create performance. Please verify input.");
                return View("~/Views/Admin/PerformanceForm.cshtml", model);
            }
        }

        [HttpGet]
        public ActionResult PerformanceList()
        {
            var mediator = new TicketMediator();
            var model = mediator.GetPerformances();

            return View("~/Views/Admin/PerformanceList.cshtml", model);
        }

    }
}
