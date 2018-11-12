using System;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Sales
{
    public class SalesProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasKey(sp => new { sp.SaleId, sp.ProductId });
            builder.Property(sp => sp.TotalProductPrice).HasColumnType("decimal(5,2)");
            SeedSaleProduct(builder);
        }

        private void SeedSaleProduct(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasData(new
            {
                SaleId = 1,
                ProductId = 1,
                LastModified = DateTime.Now,
                Quantity = 1,
                TotalProductPrice = 3m
            });
            builder.HasData(new
            {
                SaleId = 1,
                ProductId = 2,
                LastModified = DateTime.Now,
                Quantity = 2,
                TotalProductPrice = 4m
            });
        }
    }
}