using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ticketing.Framework.Data;
using Ticketing.Framework.DBModels;
using Ticketing.Framework.Models.Cart;
using Ticketing.Framework.Models.Common;
using Ticketing.Framework.Models.Ticket;
using Ticketing.Framework.Transformers;

namespace Ticketing.Framework.Mediators
{
    public class TicketMediator
    {
        public List<EventVM> GetEvents()
        {
            var events = new List<EventVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new EventRepository(db);
                IEnumerable<Event> dbEvents = resp.GetAll();

                var transformer = new EventTransformer();
                events = transformer.Transform(dbEvents);
            }

            return events;
        }

        public List<EventVM> GetActiveEvents()
        {
            var events = new List<EventVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new EventRepository(db);
                IEnumerable<Event> dbEvents = resp.Get(e => e.status == 1);

                var transformer = new EventTransformer();
                events = transformer.Transform(dbEvents);
            }

            return events;
        }

        public List<EventItem> GetEventItems()
        {
            List<EventVM> events = GetEvents();
            var items = new List<EventItem>();

            foreach (var ev in events)
            {
                var model = new EventItem
                {
                    Name = ev.Name,
                    EventId = ev.Id
                };
                items.Add(model);
            }
            
            return items;
        }

        public EventVM GetEvent(int id)
        {
            var ev = new EventVM();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new EventRepository(db);
                Event dbEvent = db.Events.FirstOrDefault(e => e.EventId == id);

                var transformer = new EventTransformer();
                ev = transformer.Transform(dbEvent);
            }
            return ev;
        }

        public bool CreateEvent(EventVM model)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var eventModel = new Event
                {
                    Name = model.Name,
                    Description = model.Description,
                    Location = model.Location,
                    Image = model.Image,
                    status = Convert.ToInt32(model.Active),
                    EventTypeId = model.Category
                };

                db.Events.Add(eventModel);
                success = db.SaveChanges() > 0;
            }

            return success;
        }

        public bool UpdateEvent(EventVM model)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new EventRepository(db);
                Event dbEvent = db.Events.FirstOrDefault(e => e.EventId == model.Id);

                dbEvent.Description = model.Description;
                dbEvent.Image = model.Image;
                dbEvent.Location = model.Location;
                dbEvent.Name = model.Name;
                dbEvent.status = Convert.ToInt32(model.Active);

                resp.Update(dbEvent);
                success = db.SaveChanges() > 0;
            }

            return success;
        }

        public List<PerformanceVM> GetPerformances(int id)
        {
            var performances = new List<PerformanceVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                var perfs = resp.Get(p => p.EventId == id);

                var transformer = new PerformanceTransformer();
                performances = transformer.Transform(perfs);
            }
            return performances;
        }

        public PerformanceVM GetPerformance(int id)
        {
            var performance = new PerformanceVM();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                var perf = resp.GetFirstOrDefault(p => p.PerformanceId == id);
                var transformer = new PerformanceTransformer();
                performance = transformer.Transform(perf);
            }

            return performance;
        }

        public List<PerformanceVM> GetAllPerformances()
        {
            var performances = new List<PerformanceVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                var perfs = resp.Get(p => p.Date > DateTime.Now && p.Event.status == 1);

                var transformer = new PerformanceTransformer();
                performances = transformer.Transform(perfs);
            }
            return performances;
        }

        public List<PerformanceVM> GetUpcomingPerformances()
        {
            var performances = new List<PerformanceVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                var perfs = resp.Get(p => p.Date > DateTime.Now && p.Event.status == 1).Take(5).OrderBy(o => o.Date);

                var transformer = new PerformanceTransformer();
                performances = transformer.Transform(perfs);
            }
            return performances;
        }

        public bool CreatePerformance(PerformanceVM model)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);

                var perf = new Performance
                {
                    Date = DateTime.Parse(model.PerformanceDate),
                    EventId = model.EventId,
                    Price = model.Price,
                    status = model.Cancelled,
                    TotalTickets = model.AvailableTickets
                };

                resp.Insert(perf);
                success = db.SaveChanges() > 0;
            }

            return success;
        }

        public bool UpdatePerformance(PerformanceVM model)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                Performance perf = resp.GetFirstOrDefault(p => p.PerformanceId == model.PerformanceId);

                perf.Date = DateTime.Parse(model.PerformanceDate);
                perf.Price = model.Price;
                perf.status = model.Cancelled;
                perf.TotalTickets = model.AvailableTickets;
                perf.EventId = model.EventId;

                resp.Update(perf);
                success = db.SaveChanges() > 0;
            }

            return success;
        }

        public List<Category> GetEventTypes()
        {
            var eventTypes = new List<Category>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new EventTypeRepository(db);
                var types = resp.GetAll().ToList();

                var transformer = new CategoryTransformer();
                eventTypes = transformer.Transform(types);
            }

            return eventTypes;
        }

        public void CompleteOrder(CartVM cart)
        {

        }

        public CartVM GetCart()
        {
            var cart = new CartVM();
            if (HttpContext.Current.Session["Cart"] == null)
            {
                HttpContext.Current.Session["Cart"] = cart;
            }
            else
                cart = (CartVM)HttpContext.Current.Session["Cart"];

            return cart;
        }

        public void ClearCart()
        {
            HttpContext.Current.Session["Cart"] = null;
        }

        public bool HasEnoughSeats(int performanceId, int quantity)
        {
            bool hasSeats = false;
            var perf = GetPerformance(performanceId);

            if (perf.AvailableTickets - quantity >= 0)
                hasSeats = true;

            return hasSeats;

        }
    }
}
