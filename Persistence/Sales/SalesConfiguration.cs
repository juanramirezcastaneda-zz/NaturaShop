using System;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Sales
{
	public class SalesConfiguration : IEntityTypeConfiguration<Sale>
	{
		public void Configure(EntityTypeBuilder<Sale> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(s => s.Date).IsRequired();
			builder.Property(s => s.Date).IsRequired();

			builder.Property(s => s.TotalPrice).IsRequired().HasColumnType("decimal(5,2)");
			SeedSalesData(builder);
		}

		private void SeedSalesData(EntityTypeBuilder<Sale> builder)
		{
			builder.HasData(new
			{
				Id = 1,
				Date = DateTime.Now.Date.AddDays(-3),
				CustomerId = 2,
				PartnerId = 3,
				// ProductId = 4,
				// UnitPrice = 5m,
				// Quantity = 1,
				TotalPrice = 3m,
				LastModified = DateTime.Now.Date.AddDays(-3)
			});
		}
	}
}
