using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RefactorThis.Models;

namespace RefactorThis.Persistence
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOption> ProductOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlite("DataSource=App_Data\\products.db");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOption>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Description).HasColumnType("varchar(23)");

                entity.Property(e => e.Id).HasColumnType("varchar(36)");

                entity.Property(e => e.Name).HasColumnType("varchar(9)");

                entity.Property(e => e.ProductId).HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeliveryPrice).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Description).HasColumnType("varchar(35)");

                entity.Property(e => e.Id).HasColumnType("varchar(36)");

                entity.Property(e => e.Name).HasColumnType("varchar(17)");

                entity.Property(e => e.Price).HasColumnType("decimal(6,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
