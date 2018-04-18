using System;
using CoffeePoint.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeePoint.Database
{
    public class DatabaseContext:DbContext
    {
        public virtual DbSet<CashierShift> CashierShifts { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        { }
    }
}