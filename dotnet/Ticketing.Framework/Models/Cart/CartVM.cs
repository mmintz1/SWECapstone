using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Ticket;

namespace Ticketing.Framework.Models.Cart
{
    public class CartVM
    {
        public decimal Total { get; set; }
        public List<PerformanceVM> Performances { get; set; }
    }
}
