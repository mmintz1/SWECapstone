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
            using (var db = new ManagementToolProjectEntities())
            {
                var orderModel = new Order
                {
                    FirstName = payment.FirstName,
                    LastName = payment.LastName,
                    BillingAdress = payment.BillingAddress.Address1,
                    BillingCity = payment.BillingAddress.City,
                    BillingState = payment.BillingAddress.State,
                    BillingZipCode = Convert.ToInt32(payment.BillingAddress.Zip)
                    
                };

                db.Orders.Add(orderModel);
                success = db.SaveChanges() > 0;
            }

            return success;
        }
    }
}
