using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.BusinessModels;

namespace Ticketing.Framework.Models.Cart
{
    public class PaymentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public bool SameAsBilling { get; set; }

        public string CreditCardType { get; set; }
        public string CVV { get; set; }
        public string CreditCardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
    }
}
