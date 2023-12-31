using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);

        void AddUser(UserDTO user);

        void UpdateUser(UserDTO user);

        void DeleteUser(int id);
    }
}