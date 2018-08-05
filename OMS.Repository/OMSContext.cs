using OMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Repository
{
    public class OMSContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Order>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasRequired(c => c.Address)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany<Transaction>(g => g.Transaction)
                .WithRequired(s => s.User)
                .HasForeignKey<int>(s => s.UserID);

            modelBuilder.Entity<User>()
                .HasRequired(c => c.Transaction)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired(s => s.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired(s => s.Address)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Variant>()
                .HasMany<Product>(g => g.Product)
                .WithRequired(s => s.Variant)
                .HasForeignKey<int>(s => s.VariantID);

            modelBuilder.Entity<Variant>()
                .HasRequired(s => s.Product)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired(s => s.Variant)
                .WithMany()
                .WillCascadeOnDelete(false);

        }
        public OMSContext() : base("OMS") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
