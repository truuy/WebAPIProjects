using System;
using System.Collections.Generic;

namespace ExpenseTracker.Models;

public partial class Expense
{
    public int ExpenseId { get; set; }

    public Guid UserId { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
