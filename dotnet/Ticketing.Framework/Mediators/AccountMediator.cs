using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Framework.Models.Account;

namespace Ticketing.Framework.Mediators
{
    public class AccountMediator
    {
        public bool RegisterUser(RegisterVM reg)
        {
            var success = false;
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new UsersRepository(db);

            //    bool emailExist = resp.AccountExist(reg.Email);

            //    if (!emailExist)
            //    {
            //        var regUser = new User
            //        {
            //            Email = reg.Email.Trim().ToLower(),
            //            FirstName = reg.FirstName,
            //            LastName = reg.LastName,
            //            Password = reg.Password,
            //            CompanyId = reg.CompanyId,
            //            Role = Roles.Employee.ToString()
            //        };
            //        resp.Insert(regUser);
            //        success = db.SaveChanges() > 0;
            //    }
            //}

            return success;
        }

        public bool Authenticate(RegisterVM user)
        {

            bool isAuthenticated = false;
            //using (var db = new ManagementToolEntities())
            //{
            //    var resp = new UsersRepository(db);

            //    var account = resp.GetFirstOrDefault(u => u.Email.Trim().ToLower() == user.Email.Trim().ToLower());

            //    if (account != null)
            //    {
            //        if (user.Password == account.Password)
            //        {
            //            isAuthenticated = true;
            //        }
            //    }
            //}

            return isAuthenticated;

        }
    }
}
