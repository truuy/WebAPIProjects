using System;
using System.Collections.Generic;

namespace ExpenseTracker.Model;

public partial class Income
{
    public int IncomeId { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public string Source { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
