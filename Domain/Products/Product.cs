﻿using System.Collections.Generic;
using Domain.Common;
using Domain.Sales;

namespace Domain.Products
{
	public class Product : IEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }
	
		public List<SaleProduct> SaleProducts { get; set; }
	}
}
