using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserService
    {

        private UserRepository userRepository; 

        public UserService()
        {

            this.userRepository = new UserRepository();


        }



        public List<UserDTO> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }








    }
}
