using System;
using System.Collections.Generic;

namespace ExpenseTracker.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
