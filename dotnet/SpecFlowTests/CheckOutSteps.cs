using System;
using TechTalk.SpecFlow;
using Ticketing.Framework.BusinessModels;
using Ticketing.Framework.DBModels;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Cart;
using Ticketing.Framework.Models.Ticket;
using Ticketing.Website.Controllers;

namespace SpecFlowTests
{
    [Binding]
    public class CheckOutSteps
    {
        [Given(@"That there are items in the shopping cart")]
        public void GivenThatThereAreItemsInTheShoppingCart()
        {
            var performance = new PerformanceVM
            {
                AvailableTickets = 1,
                Cancelled = false,
                EventId = 1,
                EventName = "TestEvent",
                LineNumber = 0,
                Location = null,
                PerformanceDate = "04/23/15",
                PerformanceId = 8,
                Price = 0,
                Quantity = 1
            };
            new EventController().AddToCart(performance);
        }

        [When(@"The User inputs the billing information and confirms the order")]
        public void WhenTheUserConfirmsTheOrder()
        {
            var payment = new PaymentVM
            {
                BillingAddress = new Address
                {
                    Address1 = "Address line 1",
                    Address2 = "Address line 2",
                    City = "City",
                    Country = null,
                    State = "State",
                    Zip = "30345"
                },
                CreditCardNumber = "0000111122223333",
                CreditCardType = "Visa",
                CVV = "888",
                Email = "Spec.Flow@specflow.com",
                ExpirationMonth = "1",
                ExpirationYear = "2015",
                FirstName = "SpecFlow",
                LastName = "FlowSpec",
                NameOnCard = "Name",
                SameAsBilling = true,
                ShippingAddress = new Address
                {
                    Address1 = "Address line 1",
                    Address2 = "Address line 2",
                    City = "City",
                    Country = null,
                    State = "State",
                    Zip = "30345"
                }
            };
            new OrderMediator().CreateOrder(payment);
        }

        [Then(@"The System updates the inventory")]
        public void ThenTheSystemUpdatesTheInventory()
        {
            var performance = new PerformanceVM
            {
                AvailableTickets = 1,
                Cancelled = false,
                EventId = 1,
                EventName = "TestEvent",
                LineNumber = 0,
                Location = null,
                PerformanceDate = "04/23/15",
                PerformanceId = 8,
                Price = 0,
                Quantity = 1
            };
            new TicketMediator().UpdatePerformance(performance);
        }

        [Then(@"The System displays order confirmation")]
        public void ThenTheSystemDisplaysOrderConfirmation()
        {
            //confirmation => CheckoutController
            //new CheckoutController().confirmation();
            ScenarioContext.Current.Pending();
        }
    }
}
