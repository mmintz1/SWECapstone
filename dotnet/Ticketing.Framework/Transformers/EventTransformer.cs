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
                Description = ev.Description,
                Id = ev.EventId,
                Image = ev.Image,
                Location = ev.Location,
                Name = ev.Name,
                Active = ev.status == 0 ? false : true
            };

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
