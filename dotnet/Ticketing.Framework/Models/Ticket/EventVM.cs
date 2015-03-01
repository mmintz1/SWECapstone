using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Models.Ticket
{
    public class EventVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public List<PerformanceVM> Performances { get; set; }
    }
}
