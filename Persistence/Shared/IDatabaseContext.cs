using Domain.Common;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared
{
	public interface IDatabaseContext
	{
		DbSet<Domain.Customers.Customer> Customers { get; set; }

		DbSet<Partner> Partners { get; set; }

		DbSet<Product> Products { get; set; }

		DbSet<Sale> Sales { get; set; }

		DbSet<T> Set<T>() where T : class, IEntity;

		void Save();
	}
}
