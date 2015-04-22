using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Framework.Transformers
{
    public class EventTransformer
    {
        public EventVM Transform(DBModels.Event ev)
        {
            var model = new EventVM
            {
                Category = ev.EventTypeId.HasValue ? (int)ev.EventTypeId : 0,
                CategoryName = ev.EventType.Type,
                Description = ev.Description,
                Id = ev.EventId,
                Image = ev.Image,
                Location = ev.Location,
                Name = ev.Name,
                Active = Convert.ToBoolean(ev.status),
                Performances = new List<PerformanceVM>()
            };

            var trans = new PerformanceTransformer();
            model.Performances = trans.Transform(ev.Performances);

            foreach (var perf in model.Performances)
            {
                perf.EventName = ev.Name;
            }
            

            return model;
        }

        public List<EventVM> Transform(IEnumerable<DBModels.Event> events)
        {
            var model = new List<EventVM>();
            foreach (var ev in events)
            {
                model.Add(Transform(ev));
            }

            return model;
        }
    }
}
