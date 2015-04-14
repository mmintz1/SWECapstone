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

            return success;
        }

        public void AddPerformanceOrder(int orderId)
        {
            var meditaor = new TicketMediator();
            var cart = meditaor.GetCart();
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
                    var success = db.SaveChanges();
                }
            }
        }
    }
}
