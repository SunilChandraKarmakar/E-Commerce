using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompletedECommerce.Databse
{
    public class ECommerceDb : DbContext 
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a => new { a.Username, a.Email, a.Phone }).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-O1NBMET; 
                                    Initial Catalog = CompletedECommerce; 
                                    Integrated Security = TRUE";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
