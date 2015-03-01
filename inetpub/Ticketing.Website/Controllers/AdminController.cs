using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Website.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult EditEvent()
        {
            var model = new EventVM();
            ViewBag.PageTitle = "Edit Event";
            return View("~/Views/Admin/EventForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditEvent(EventVM model)
        {
            ViewBag.PageTitle = "Edit Event";
            return View("~/Views/Admin/EventForm.cshtml", model);
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
            ViewBag.PageTitle = "Create Event";
            return View("~/Views/Admin/EventForm.cshtml", model);
        }

        [HttpGet]
        public ActionResult EditPerformance()
        {
            var model = new PerformanceVM();
            ViewBag.PageTitle = "Edit Performance";
            return View("~/Views/Admin/PerformanceForm.cshtml", model);
        }

        [HttpPost]
        public ActionResult EditPerformance(PerformanceVM model)
        {
            ViewBag.PageTitle = "Edit Performance";
            return View("~/Views/Admin/PerformanceForm.cshtml", model);
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
            ViewBag.PageTitle = "Create Performance";
            return View("~/Views/Admin/PerformanceForm.cshtml", model);
        }

    }
}
