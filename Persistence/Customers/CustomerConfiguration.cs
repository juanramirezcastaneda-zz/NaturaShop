using System;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Customers
{
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

			SeedCustomerData(builder);
		}

		private static void SeedCustomerData(EntityTypeBuilder<Customer> builder)
		{
			builder.HasData(new
			{
				Id = 2,
				Name = "TestCustomer",
				PhoneNumber = (uint)7,
				LastModified = DateTime.Now
			});
		}
	}
}
