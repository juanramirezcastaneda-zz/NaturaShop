﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;

namespace Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery: IGetProductsListQuery
    {
	    private readonly IDatabaseService _database;

		public GetProductsListQuery(IDatabaseService database)
		{
			_database = database;
		}

		public List<ProductModel> Execute()
		{
			var products = _database.Products.Select(p => new ProductModel
			{
				Id = p.Id,
				Name = p.Name,
				UnitPrice = p.Price
			});

			return products.ToList();
		}
	}
}
