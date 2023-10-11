using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {

        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public string firstname { get; }
        public string lastname { get; }


        public Shoppingcart shoppingCart { get; }


        public User(string username)
        {

            this.Username = username;
        }










    }

}
