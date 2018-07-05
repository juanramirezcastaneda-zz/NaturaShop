using System;
using System.Linq;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;

namespace Persistence.Shared
{
	public class DatabaseInitializer
	{
		public DatabaseInitializer(DatabaseContext database)
		{
			database.Database.EnsureCreated();
			CreateCustomers(database);
			CreatePartners(database);
			CreateProducts(database);
			CreateSales(database);
		}

		private void CreateCustomers(DatabaseContext database)
		{
			database.Customers.Add(new Customer() { Name = "Martin Fowler" });

			database.Customers.Add(new Customer() { Name = "Uncle Bob" });

			database.Customers.Add(new Customer() { Name = "Kent Beck" });

			database.SaveChanges();
		}

		private void CreatePartners(DatabaseContext database)
		{
			database.Partners.Add(new Partner() { Name = "Eric Evans" });

			database.Partners.Add(new Partner() { Name = "Greg Young" });

			database.Partners.Add(new Partner() { Name = "Udi Dahan" });

			database.SaveChanges();
		}

		private void CreateProducts(DatabaseContext database)
		{
			database.Products.Add(new Product() { Name = "Spaghetti", Price = 5m });

			database.Products.Add(new Product() { Name = "Lasagna", Price = 10m });

			database.Products.Add(new Product() { Name = "Ravioli", Price = 15m });

			database.SaveChanges();
		}

		private void CreateSales(DatabaseContext database)
		{
			var customers = database.Customers.ToList();

			var partners = database.Partners.ToList();

			var products = database.Products.ToList();

			database.Sales.Add(new Sale()
			{
				Date = DateTime.Now.Date.AddDays(-3),
				Customer = customers[0],
				Partner = partners[0],
				Product = products[0],
				UnitPrice = 5m,
				Quantity = 1
			});

			database.Sales.Add(new Sale()
			{
				Date = DateTime.Now.Date.AddDays(-2),
				Customer = customers[1],
				Partner = partners[1],
				Product = products[1],
				UnitPrice = 10m,
				Quantity = 2
			});

			database.Sales.Add(new Sale()
			{
				Date = DateTime.Now.Date.AddDays(-1),
				Customer = customers[2],
				Partner = partners[2],
				Product = products[2],
				UnitPrice = 15m,
				Quantity = 3
			});

			database.SaveChanges();
		}
	}
}
