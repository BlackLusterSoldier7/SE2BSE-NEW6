using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository
    {

        public List<UserDTO> GetAllUsers()
        {
            // ToDo: Get user data from database 
            // Hack: hard-coded for now 
            return new List<UserDTO>()
            {
                new UserDTO()
                {
                    Username = "Ema_ema",
                    Email = "ema.m@outlook.com",
                    Firstname = "Ema",
                    Lastname = "M"
                },

                new UserDTO()
                {
                    Username = "burak_b",
                    Email = "burak.b@outlook.com",
                    Firstname = "Burak",
                    Lastname = "B"
                },

                new UserDTO()
                {
                    Username = "test",
                    Email = "test@outlook.com",
                    Firstname = "test",
                    Lastname = "test"
                }
            };
        }
    }
}