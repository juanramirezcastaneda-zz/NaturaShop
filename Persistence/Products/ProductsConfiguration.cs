using System;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Products
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pr => pr.Id);
            builder.Property(pr => pr.Name).IsRequired().HasMaxLength(50);
            builder.Property(pr => pr.UnitPrice).IsRequired().HasColumnType("decimal(5,2)");

            SeedProductData(builder);
        }

        private static void SeedProductData(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new
            {
                Id = 1,
                Name = "TestProduct",
                UnitPrice = 3m,
                LastModified = DateTime.Now
            });

            builder.HasData(new
            {
                Id = 2,
                Name = "TestProduct2",
                UnitPrice = 2m,
                LastModified = DateTime.Now.AddDays(-1)
            });

        }
    }
}
