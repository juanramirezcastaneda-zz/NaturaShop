using System;
using Domain.Common;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence.Customers;
using Persistence.Partners;
using Persistence.Products;

namespace Persistence.Shared
{
	public class DatabaseContext : DbContext, IDatabaseContext
	{
		public DbSet<Domain.Customers.Customer> Customers { get; set; }

		public DbSet<Partner> Partners { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Sale> Sales { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new PartnersConfiguration());
			modelBuilder.ApplyConfiguration(new ProductsConfiguration());
	
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			const string connectionString =
				"Initial Catalog=NaturaShop;Integrated Security=SSPI;Persist Security Info=False;Data Source=M3078483\\SQLEXPRESS";
			optionsBuilder.UseSqlServer(connectionString);
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
