using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDD.Product.Domain.Product.ProductEnum;

namespace DDD.Product.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product.Domain.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Product.Domain.Product.Product> builder)
        {
            builder.Property(t => t.Type).HasConversion(
                                 v => v.ToString(),
                                 v => (ProductType)Enum.Parse(typeof(ProductType), v));
            builder.Property(t => t.Color).HasConversion(
                                      v => v.ToString(),
                                      v => (ProductColor)Enum.Parse(typeof(ProductColor), v));
            builder.HasData(Product.Domain.Product.Product.Seed());
        }
    }
}
