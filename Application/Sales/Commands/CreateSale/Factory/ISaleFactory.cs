using System;
using System.Collections.Generic;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;

namespace Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
	    Sale Create(DateTime date, Customer customer, Partner partner, IEnumerable<Product> products);
	}
}
