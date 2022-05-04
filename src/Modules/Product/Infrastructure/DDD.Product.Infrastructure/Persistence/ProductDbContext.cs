using DDD.Shared.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Infrastructure.Persistence
{
#nullable disable
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // register fluent entity configuration
            var entitiesAssembly = typeof(ProductDbContext).Assembly;
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
