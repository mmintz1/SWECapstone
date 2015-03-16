using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Common;

namespace Ticketing.Framework.Models.Ticket
{
    public class EventVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Category { get; set; }
        public string Image { get; set; }
        public List<PerformanceVM> Performances { get; set; }
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
        public bool Active { get; set; }
    }
}
