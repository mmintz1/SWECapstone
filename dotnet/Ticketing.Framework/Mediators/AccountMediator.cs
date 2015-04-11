using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.DBModels;
using Ticketing.Framework.Models.Account;

namespace Ticketing.Framework.Mediators
{
    public class AccountMediator
    {
        public bool RegisterUser(RegisterVM reg)
        {
            var success = false;
            using (var db = new ManagementToolProjectEntities())
            {
                bool emailExist = db.Users.FirstOrDefault(u => u.EmailAddress == reg.Email) != null;

                if (!emailExist)
                {
                    var regUser = new User
                    {
                        EmailAddress = reg.Email.Trim().ToLower(),
                        FirstName = reg.FirstName,
                        LastName = reg.LastName,
                        Password = reg.Password,
                        status = true
                    };
                    db.Users.Add(regUser);
                    success = db.SaveChanges() > 0;
                }
            }

            return success;
        }

        public bool Authenticate(RegisterVM user)
        {

            bool isAuthenticated = false;
            using (var db = new ManagementToolProjectEntities())
            {
                var account = db.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == user.Email.Trim().ToLower());

                if (account != null)
                {
                    if (user.Password == account.Password)
                    {
                        isAuthenticated = true;
                    }
                }
            }

            return isAuthenticated;

        }
    }
}
