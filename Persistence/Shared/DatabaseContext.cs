using Domain.Common;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Persistence.Customers;
using Persistence.Partners;
using Persistence.Products;
using Persistence.Sales;

namespace Persistence.Shared
{
	public class DatabaseContext : DbContext, IDatabaseContext
	{
		public DbSet<Domain.Customers.Customer> Customers { get; set; }

		public DbSet<Partner> Partners { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Sale> Sales { get; set; }

		public static readonly LoggerFactory DbLoggerFactory
			= new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) =>
				category == DbLoggerCategory.Database.Command.Name 
				&& level == LogLevel.Information, true) });

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			modelBuilder.ApplyConfiguration(new PartnersConfiguration());
			modelBuilder.ApplyConfiguration(new ProductsConfiguration());
			modelBuilder.ApplyConfiguration(new SalesConfiguration());
			
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			const string connectionString =
				"Initial Catalog=NaturaShop;Integrated Security=SSPI;Persist Security Info=False;Data Source=M3078483\\SQLEXPRESS";

			optionsBuilder.UseLoggerFactory(DbLoggerFactory);
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.EnableSensitiveDataLogging();
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
