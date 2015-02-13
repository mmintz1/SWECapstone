using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Framework.Models.Account
{
    public class RegisterVM
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
        public int Id { get; set; }
    }
}
