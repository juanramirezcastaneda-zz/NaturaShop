using System;
using System.Collections.Generic;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Factory
{
	public class SaleFactory : ISaleFactory
	{
		public Sale Create(DateTime date, Customer customer, Partner partner,
			IEnumerable<Product> products, int quantity)
		{
			var saleProducts = new List<SaleProduct>();
			foreach (var product in products)
			{
				var saleProduct = new SaleProduct{
					ProductId = product.Id,
					Product = product
				};
				saleProducts.Add(saleProduct);
			}

			return new Sale
			{
				Customer = customer,
				Date = date,
				Partner = partner,
				Quantity = quantity,
				SaleProducts = saleProducts
			};
		}
	}
}
