using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.DBModels;
using Ticketing.Framework.Models.Cart;

namespace Ticketing.Framework.Mediators
{
    public class OrderMediator
    {
        public bool CreateOrder(PaymentVM payment)
        {
            var success = false;
            var mediator = new TicketMediator();
            var cart = mediator.GetCart();

            foreach (var perf in cart.Performances)
            {
                var performance = mediator.GetPerformance(perf.PerformanceId);

                if (performance.AvailableTickets - perf.Quantity >= 0)
                {
                    success = true;

                    if (!success)
                        break;
                }
            }

            if (success)
            {
                using (var db = new ManagementToolProjectEntities())
                {
                    var date = payment.ExpirationMonth + "/1/" + payment.ExpirationYear;
                    var expiry = DateTime.Parse(date);

                    var orderModel = new Order
                    {
                        FirstName = payment.FirstName,
                        LastName = payment.LastName,
                        BillingAdress = payment.BillingAddress.Address1,
                        BillingCity = payment.BillingAddress.City,
                        BillingState = payment.BillingAddress.State,
                        BillingZipCode = Convert.ToInt32(payment.BillingAddress.Zip),
                        ShippingAdress = payment.ShippingAddress.Address1,
                        ShippingCity = payment.ShippingAddress.City,
                        ShippingState = payment.ShippingAddress.State,
                        ShippingZipCode = Convert.ToInt32(payment.ShippingAddress.Zip),
                        ExpirationDate = expiry,
                        CreditCard = payment.CreditCardNumber,
                        status = 1

                    };

                    var order = db.Orders.Add(orderModel);
                    success = db.SaveChanges() > 0;

                    if (success)
                    {
                        AddPerformanceOrder(order.OrderId);
                    }
                }
            }

            return success;
        }

        public void AddPerformanceOrder(int orderId)
        {
            var success = false;
            var mediator = new TicketMediator();
            var cart = mediator.GetCart();
            using (var db = new ManagementToolProjectEntities())
            {
                foreach (var perf in cart.Performances)
                {
                    var perfOrder = new OrderPerformanceMapping2
                    {
                        OderId = orderId,
                        PerformanceId = perf.PerformanceId,
                        Quantity = perf.Quantity
                    };

                    db.OrderPerformanceMapping2.Add(perfOrder);
                    success = db.SaveChanges() > 0;

                    if (success)
                    {
                        var performance = mediator.GetPerformance(perf.PerformanceId);
                        performance.AvailableTickets = performance.AvailableTickets - perf.Quantity;
                        success = mediator.UpdatePerformance(performance);
                    }
                }
            }

        }
    }
}
