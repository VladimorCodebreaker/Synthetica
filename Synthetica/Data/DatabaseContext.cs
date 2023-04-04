using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Synthetica.Models;

namespace Synthetica.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Substance_Drug>().HasKey(sd => new
            {
                sd.SubstanceId,
                sd.DrugId
            });

            modelBuilder.Entity<Substance_Drug>().HasOne(s => s.Substance).WithMany(sd => sd.Substance_Drugs).HasForeignKey(s => s.SubstanceId);
            modelBuilder.Entity<Substance_Drug>().HasOne(d => d.Drug).WithMany(sd => sd.Substance_Drugs).HasForeignKey(d => d.DrugId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Substance> Substances { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Substance_Drug> Substance_Drugs { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

