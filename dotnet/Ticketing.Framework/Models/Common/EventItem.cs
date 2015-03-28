using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Models.Common
{
    public class EventItem
    {
        public string Name { get; set; }
        public int EventId { get; set; }
        public bool SelectedIndicator { get; set; }
    }
}
