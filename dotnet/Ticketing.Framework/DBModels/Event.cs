//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ticketing.Framework.DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.Performances = new HashSet<Performance>();
        }
    
        public int EventId { get; set; }
        public Nullable<int> EventTypeId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> CreateById { get; set; }
        public string Image { get; set; }
        public int status { get; set; }
    
        public virtual EventType EventType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
    }
}
