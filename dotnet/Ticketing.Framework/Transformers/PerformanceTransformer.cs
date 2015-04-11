using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Framework.Transformers
{
    public class PerformanceTransformer
    {
        public PerformanceVM Transform(DBModels.Performance perf)
        {
            var model = new PerformanceVM
            {
                AvailableTickets = (int)perf.TotalTickets,
                Cancelled = perf.status,
                EventId = (int)perf.EventId,
                PerformanceId = perf.PerformanceId,
                PerformanceDate = ((DateTime)perf.Date).ToString("MM/dd/yy"),
                Price = (decimal)perf.Price,
                EventName = perf.Event.Name,
                Location = perf.Event.Location
            };

            return model;
        }

        public List<PerformanceVM> Transform(IEnumerable<DBModels.Performance> performances)
        {
            var model = new List<PerformanceVM>();
            if (performances != null && performances.Count() > 0)
            {
                foreach (var perf in performances)
                {
                    model.Add(Transform(perf));
                }
            }

            return model;
        }
    }
}
