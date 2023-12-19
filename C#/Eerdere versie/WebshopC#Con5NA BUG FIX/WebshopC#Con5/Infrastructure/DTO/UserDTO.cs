using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UserDTO
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public UserDTO() { }
        

        public UserDTO(string username, string email, string firstname, string lastname)
        {
            Username = username;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;

        }


    }
}
