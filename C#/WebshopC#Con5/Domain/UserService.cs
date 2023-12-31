
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserService
    {
        private IUserRepository userRepository; 






        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository; 
        }

        public List<UserDTO> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}