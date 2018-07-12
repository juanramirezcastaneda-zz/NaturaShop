using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Products;
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
			var product = ReadProduct();
			Console.ReadLine();
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
