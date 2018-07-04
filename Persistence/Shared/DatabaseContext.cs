using System;
using Domain.Common;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared
{
	public class DatabaseContext : DbContext, IDatabaseContext
	{
		public DbSet<Domain.Customers.Customer> Customers { get; set; }

		public DbSet<Partner> Partners { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Sale> Sales { get; set; }

		public DatabaseContext()
		{

		}

		public new DbSet<T> Set<T>() where T : class, IEntity
		{
			return base.Set<T>();
		}

		public void Save()
		{
			SaveChanges();
		}
	}
}
