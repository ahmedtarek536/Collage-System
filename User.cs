using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageSystem
{
    internal class User
    {
       public string fullName;
       public string email;
       public string password;
       public string role;
        public User(string fullName, string email, string password, string role)
        {
            this.fullName = fullName;
            this.email = email;
            this.password = password;
            this.role = role;
        }
    }
}
