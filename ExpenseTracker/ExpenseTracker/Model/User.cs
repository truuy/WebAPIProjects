using System;
using System.Collections.Generic;

namespace ExpenseTracker.Model;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Balance> Balances { get; set; } = new List<Balance>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<FinancialGoal> FinancialGoals { get; set; } = new List<FinancialGoal>();

    public virtual ICollection<Income> Incomes { get; set; } = new List<Income>();
}
