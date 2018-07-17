using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Persistence.Products;
using Persistence.Shared;

namespace DatabaseInteraction
{
	class Program
	{
		static void Main(string[] args)
		{
			//InsertProduct();
			//InsertProducts();
			//var product = ReadProduct();

			//InsertSales();
			//ReadIncludingRelationships();
			ReadIncludingRelationshipsUsingExplicitLoad();
			Console.ReadLine();
		}

		private static void ReadIncludingRelationshipsUsingExplicitLoad()
		{  
			using (var context = new DatabaseContext())
			{
				var sale = context.Sales.FirstOrDefault();
				context.Entry(sale).Reference(s => s.Partner).Load();
			}
		}

		private static void ReadIncludingRelationships()
		{
			using (var context = new DatabaseContext())
			{
				var sales = context.Sales.Include(s => s.Customer).ToList(); 	
			}
		}

		private static void InsertSales()
		{
			using (var context = new DatabaseContext())
			{
				var newSale = new Sale
				{
					UnitPrice = 5m,
					Quantity = 1,
					Date = DateTime.Now,
					Customer = new Customer
					{
						Name = "El Dandi",
						PhoneNumber = 7887
					},
					Partner = new Partner
					{
						Name = "Betty",
						PhoneNumber = 456
					},
					Product = new Product
					{
						Name = "Almond Milk",
						Price = 5m
					}
				};
				context.Sales.Add(newSale);
				context.SaveChanges();
			}
		}

		private static void InsertProducts()
		{
			using (var context = new DatabaseContext())
			{
				var product = new Product { Name = "TestAfterShave", Price = 7m };
				var product2 = new Product { Name = "TestShampoo", Price = 3m };
				context.Products.AddRange(new List<Product>{product, product2});
				context.SaveChanges();
			}
		}

		private static Product ReadProduct()
		{
			using (var context = new DatabaseContext())
			{
				return context.Products.Find(4);
				//IProductRepository productRepository = new ProductsRepository(context);
				//var products = productRepository.find();
				//return products.Single(p => p.Id == 4);
			}
		}

		private static void InsertProduct()
		{
			using (var context = new DatabaseContext())
			{
				var product = new Product { Name = "TestLotion", Price = 7m };
				context.Products.Add(product);
				context.SaveChanges();
			}
		}


	}
}
