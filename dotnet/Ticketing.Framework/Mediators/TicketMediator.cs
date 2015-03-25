using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    status = 0,
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
            var perf = new PerformanceVM();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                resp.Get(p => p.Date > DateTime.Now && p.TotalTickets > 0);
            }

            return perf;
        }

        public List<PerformanceVM> GetAllPerformances()
        {
            var performances = new List<PerformanceVM>();
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);
                var perfs = resp.Get(p => p.Date > DateTime.Now);

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
                var perfs = resp.Get(p => p.Date > DateTime.Now).Take(5).OrderBy(o => o.Date);

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
    }
}
