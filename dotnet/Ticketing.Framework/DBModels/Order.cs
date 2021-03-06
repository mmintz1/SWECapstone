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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderPerformanceMapping2 = new HashSet<OrderPerformanceMapping2>();
        }
    
        public int OrderId { get; set; }
        public Nullable<int> PerformanceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShippingAdress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public Nullable<int> ShippingZipCode { get; set; }
        public string CreditCard { get; set; }
        public Nullable<int> CardTypeId { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> TicketNumber { get; set; }
        public string BillingAdress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public Nullable<int> BillingZipCode { get; set; }
        public int status { get; set; }
    
        public virtual CardType CardType { get; set; }
        public virtual Performance Performance { get; set; }
        public virtual ICollection<OrderPerformanceMapping2> OrderPerformanceMapping2 { get; set; }
    }
}
