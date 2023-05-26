using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
        public interface IUserRepository
        {
            User GetUserById(Guid userId);
            User GetByUsername(string username);
            IEnumerable<User> GetAllUsers();
            
        //Methods
            void AddUser(User user);
            void UpdateUser(User user);
            void DeleteUser(User user);
        }
}
