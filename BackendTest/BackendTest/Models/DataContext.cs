using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductSku> ProductSkus { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<DbResult> Quantities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductSkus);
        }
    }
}
