using System;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CoffeePoint.Database
{
    public class DatabaseContext:DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<CashierShift> CashierShifts { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(a => a.ClosedShifts).WithOne(a => a.ClosedByUser);
            modelBuilder.Entity<User>().HasMany(a => a.OpenedShifts).WithOne(a => a.OpenedByUser);
        }
    }
}