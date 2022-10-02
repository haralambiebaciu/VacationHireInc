using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.Bills;
using Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<VehicleBill>()
            .HasOne(x => x.Bill)
            .WithOne(x => x.VehicleBill)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VehicleItem>()
            .HasOne(x => x.Item)
            .WithOne(x => x.VehicleItem)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bill>()
            .HasOne(x => x.Order)
            .WithOne(x => x.Bill)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bill>()
            .HasOne(x => x.User)
            .WithMany(x => x.Bills)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Bill>()
            .HasOne(x => x.Customer)
            .WithMany(x => x.Bills)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Item)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<VehicleBill> VehicleBills { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<VehicleItem> VehicleItems { get; set; }

    public DbSet<Order> Orders { get; set; }



}