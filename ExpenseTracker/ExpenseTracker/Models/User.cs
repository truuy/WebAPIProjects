using System;
using System.Collections.Generic;

namespace ExpenseTracker.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
