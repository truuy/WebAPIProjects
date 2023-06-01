using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Model;

public partial class ExpenseTrackerContext : DbContext
{
    public ExpenseTrackerContext()
    {
    }

    public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<FinancialGoal> FinancialGoals { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Trusted_Connection=true;Database=ExpenseTrackerDatabase;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.HasKey(e => e.BalanceId).HasName("PK__balance__18188B5B062611E7");

            entity.ToTable("balance");

            entity.Property(e => e.BalanceId)
                .ValueGeneratedNever()
                .HasColumnName("balance_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Balances)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__balance__userID__60A75C0F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__23CAF1F8E8296608");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("categoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__expenses__3672730ED6A23082");

            entity.ToTable("expenses");

            entity.Property(e => e.ExpenseId)
                .ValueGeneratedNever()
                .HasColumnName("expenseID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__expenses__userID__4AB81AF0");

            entity.HasMany(d => d.Tags).WithMany(p => p.Expenses)
                .UsingEntity<Dictionary<string, object>>(
                    "ExpenseTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__expenseTa__TagID__2E1BDC42"),
                    l => l.HasOne<Expense>().WithMany()
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__expenseTa__Expen__2D27B809"),
                    j =>
                    {
                        j.HasKey("ExpenseId", "TagId").HasName("PK__expenseT__C2120057BA058A1A");
                        j.ToTable("expenseTags");
                        j.IndexerProperty<int>("ExpenseId").HasColumnName("ExpenseID");
                        j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                    });
        });

        modelBuilder.Entity<FinancialGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__financia__7E225E91B2456CAC");

            entity.ToTable("financial_goals");

            entity.Property(e => e.GoalId)
                .ValueGeneratedNever()
                .HasColumnName("goalID");
            entity.Property(e => e.CurrentAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("current_amount");
            entity.Property(e => e.Deadline)
                .HasColumnType("date")
                .HasColumnName("deadline");
            entity.Property(e => e.GoalName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("goal_name");
            entity.Property(e => e.TargetAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("target_amount");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.FinancialGoals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__financial__userI__619B8048");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.IncomeId).HasName("PK__income__5FC78A038ACD59A3");

            entity.ToTable("income");

            entity.Property(e => e.IncomeId)
                .ValueGeneratedNever()
                .HasColumnName("incomeID");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Source)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("source");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__income__userID__628FA481");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__tags__50FC0177B632C896");

            entity.ToTable("tags");

            entity.Property(e => e.TagId)
                .ValueGeneratedNever()
                .HasColumnName("tagID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tmp_ms_x__CB9A1CDF8B9A9BE8");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("userID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
