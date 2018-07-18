using System;
using Domain.Partners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Partners
{
	public class PartnersConfiguration : IEntityTypeConfiguration<Partner>
	{
		public void Configure(EntityTypeBuilder<Partner> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

			SeedPartnerData(builder);
		}

		private static void SeedPartnerData(EntityTypeBuilder<Partner> builder)
		{
			builder.HasData(new
			{
				Id = 3,
				Name = "TestPartner",
				PhoneNumber = (uint)7,
				LastModified = DateTime.Now
			});
		}
	}
}
