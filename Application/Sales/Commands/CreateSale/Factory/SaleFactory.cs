using System;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Factory
{
	public class SaleFactory : ISaleFactory
	{
		public Sale Create(DateTime date, Customer customer, Partner partner,
			Product product, int quantity)
		{
			return new Sale
			{
				Customer = customer,
				Date = date,
				Partner = partner,
				Quantity = quantity,
				Product = product,
				UnitPrice = product.Price
			};
		}
	}
}
