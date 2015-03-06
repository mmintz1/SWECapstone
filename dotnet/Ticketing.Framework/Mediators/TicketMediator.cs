using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new ProjectRepository(db);

            //    var project = new Project
            //    {
            //        Title = model.Title,
            //        Description = model.Description,
            //        ProjectManager = model.Manager,
            //        Status = model.Status.ToString(),
            //        DueDate = DateTime.Parse(model.DueDate),
            //        CompanyId = model.CompanyId,
            //        TeamMembers = string.Join(";", model.ProjectEmployees)
            //    };

            //    resp.Insert(project);
            //    success = db.SaveChanges() > 0;
            //}

            return success;
        }

        public bool UpdateEvent(EventVM model)
        {
            var success = false;
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new ProjectRepository(db);
            //    Project dbProject = resp.GetFirstOrDefault(p => p.ProjectID == model.Id);

            //    dbProject.Description = model.Description;
            //    dbProject.DueDate = DateTime.Parse(model.DueDate);
            //    dbProject.ProjectManager = model.Manager;
            //    dbProject.Status = model.Status.ToString();
            //    dbProject.Title = model.Title;

            //    resp.Update(dbProject);
            //    success = db.SaveChanges() > 0;
            //}

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
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new ProjectRepository(db);

            //    var project = new Project
            //    {
            //        Title = model.Title,
            //        Description = model.Description,
            //        ProjectManager = model.Manager,
            //        Status = model.Status.ToString(),
            //        DueDate = DateTime.Parse(model.DueDate),
            //        CompanyId = model.CompanyId,
            //        TeamMembers = string.Join(";", model.ProjectEmployees)
            //    };

            //    resp.Insert(project);
            //    success = db.SaveChanges() > 0;
            //}

            return success;
        }

        public bool UpdatePerformance(PerformanceVM model)
        {
            var success = false;
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new ProjectRepository(db);
            //    Project dbProject = resp.GetFirstOrDefault(p => p.ProjectID == model.Id);

            //    dbProject.Description = model.Description;
            //    dbProject.DueDate = DateTime.Parse(model.DueDate);
            //    dbProject.ProjectManager = model.Manager;
            //    dbProject.Status = model.Status.ToString();
            //    dbProject.Title = model.Title;

            //    resp.Update(dbProject);
            //    success = db.SaveChanges() > 0;
            //}

            return success;
        }
    }
}
