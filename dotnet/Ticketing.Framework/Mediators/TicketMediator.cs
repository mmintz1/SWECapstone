﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Data;
using Ticketing.Framework.DBModels;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Framework.Mediators
{
    public class TicketMediator
    {
        public List<EventVM> GetEvents()
        {
            var events = new List<EventVM>();

            return events;
        }

        public EventVM GetEvent(int id)
        {
            var ev = new EventVM();

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
                    status = 0
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

        public List<PerformanceVM> GetPerformances()
        {
            var performances = new List<PerformanceVM>();

            return performances;
        }

        public PerformanceVM GetPerformance(int id)
        {
            var perf = new PerformanceVM();

            return perf;
        }

        public bool CreatePerformance(PerformanceVM model)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var resp = new PerformanceRepository(db);

                var perf = new Performance
                {
                    Date = model.PerformanceDate,
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
                Performance perf = resp.GetFirstOrDefault(p => p.PerformanceId == model.Id);

                perf.Date = model.PerformanceDate;
                perf.Price = model.Price;
                perf.status = model.Cancelled;
                perf.TotalTickets = model.AvailableTickets;
                perf.EventId = model.EventId;

                resp.Update(perf);
                success = db.SaveChanges() > 0;
            }

            return success;
        }
    }
}
