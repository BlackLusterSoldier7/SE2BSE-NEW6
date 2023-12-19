using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserDTO> users;

        public UserRepository()
        {
            users = new List<UserDTO>
            {
                new UserDTO { Id = 1, Username = "Jan_de_Vries", Email = "jan.de.vries@outlook.com", Firstname = "Jan", Lastname = "Vries" },
                new UserDTO { Id = 2, Username = "Marieke", Email = "marieke.visser@outlook.com", Firstname = "Marieke", Lastname = "Visser" },
                new UserDTO { Id = 3, Username = "Piet_50", Email = "piet.natuur.wandelaar@outlook.com", Firstname = "Piet", Lastname = "aaa" }
            };
        }

        /*
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
        } */

        public void AddUser(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            int maxId = 0;
            foreach (var u in users)
            {
                if (u.Id > maxId)
                {
                    maxId = u.Id;
                }
            }

            user.Id = maxId + 1;
            users.Add(user);
        }

        public void DeleteUser(int id)
        {
            UserDTO userToRemove = null;

            foreach (var u in users)
            {
                if (u.Id == id)
                {
                    userToRemove = u;
                    break;
                }
            }

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            return new List<UserDTO>(users);
        }

        public UserDTO GetUserById(int id)
        {
            foreach (var u in users)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            return null; // If User not found. 
        }

        public void UpdateUser(UserDTO user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == user.Id)
                {
                    users[i].Username = user.Username;
                    users[i].Email = user.Email;
                    users[i].Firstname = user.Firstname;
                    users[i].Lastname = user.Lastname;
                    return;
                }
            }
            throw new ArgumentException("User not found", nameof(user));
        }
    }
}