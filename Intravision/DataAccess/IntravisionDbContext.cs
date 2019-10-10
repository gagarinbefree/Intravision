using Intravision.DataAccess.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intravision.DataAccess
{
    public class IntravisionDbContext : DbContext
    {
        public IntravisionDbContext(DbContextOptions<IntravisionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasMaxLength(1024);

                entity.Property(e => e.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<Coin>(entity =>
            {
                entity.ToTable("Coin");

                entity.Property(e => e.ParValue)
                    .IsRequired();
            });
        }
    }
}
