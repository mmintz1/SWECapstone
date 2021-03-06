﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Models.Ticket
{
    public class PerformanceVM
    {
        public int PerformanceId { get; set; }
        [Required(ErrorMessage = "Please enter a date")]
        public string PerformanceDate { get; set; }
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        public bool Cancelled { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public int LineNumber { get; set; }
    }
}
