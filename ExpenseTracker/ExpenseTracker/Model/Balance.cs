using System;
using System.Collections.Generic;

namespace ExpenseTracker.Model;

public partial class Balance
{
    public int BalanceId { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; } = null!;
}
