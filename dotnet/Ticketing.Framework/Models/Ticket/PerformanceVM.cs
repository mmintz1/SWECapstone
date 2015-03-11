using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Models.Ticket
{
    public class PerformanceVM
    {
        public int Id { get; set; }
        public DateTime PerformanceDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        public bool Cancelled { get; set; }
        public int EventId { get; set; }
    }
}
