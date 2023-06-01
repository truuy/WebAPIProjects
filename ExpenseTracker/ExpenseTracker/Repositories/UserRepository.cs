using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Model;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerContext _expenseTrackerContext;

        public UserRepository(ExpenseTrackerContext _expenseTrackerContext)
        {
            this._expenseTrackerContext = _expenseTrackerContext;
        }

        //GET BY ID
        public User GetUserById(Guid userId)
        {
            return _expenseTrackerContext.Users.FirstOrDefault(u => u.UserId == userId);
        }

        //GET BY USERNAME
        public User GetByUsername(string username)
        {
            return _expenseTrackerContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetAllUsers() 
        {
            return _expenseTrackerContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            _expenseTrackerContext.Users.Add(user);
            _expenseTrackerContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _expenseTrackerContext.Users.Update(user);
            _expenseTrackerContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _expenseTrackerContext.Users.Remove(user);
            _expenseTrackerContext.SaveChanges();
        }
    }
}
