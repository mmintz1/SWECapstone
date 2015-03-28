using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Common;

namespace Ticketing.Framework.Models.Ticket
{
    public class BuyTicketsVM
    {
        public List<PerformanceVM> Performances { get; set; }
        public List<Category> Categories { get; set; }
        public List<EventItem> Events { get; set; }
        public string ToDate { get; set; }
        public string FromDate { get; set; }
        public string LblToDate { get; set; }
        public string LblFromDate { get; set; }
    }
}
