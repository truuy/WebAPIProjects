using System;
using System.Collections.Generic;

namespace ExpenseTracker.Model;

public partial class FinancialGoal
{
    public int GoalId { get; set; }

    public Guid? UserId { get; set; }

    public string GoalName { get; set; } = null!;

    public decimal TargetAmount { get; set; }

    public decimal CurrentAmount { get; set; }

    public DateTime? Deadline { get; set; }

    public virtual User? User { get; set; }
}
