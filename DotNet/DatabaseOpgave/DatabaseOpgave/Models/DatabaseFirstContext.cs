using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseOpgave.Models
{
    public partial class DatabaseFirstContext : DbContext
    {
        public DatabaseFirstContext()
        {
        }

        public DatabaseFirstContext(DbContextOptions<DatabaseFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Merchant> Merchants { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=DatabaseFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Countrie__A25C5AA6AC215B24");

                entity.Property(e => e.ContinentName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Merchant>(entity =>
            {
                entity.HasIndex(e => e.AdminId, "IX_Merchants_AdminID");

                entity.HasIndex(e => e.CountryCode, "IX_Merchants_CountryCode");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.MerchantName).HasMaxLength(100);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Merchants)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Orders_UserId");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderItems_ProductId");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.MerchantId, "IX_Products_MerchantId");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Merchant)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MerchantId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.CountryCode, "IX_Users_CountryCode");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryCode);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
