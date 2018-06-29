using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMoqCore;
using Domain.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Products.Queries.GetProductsList
{
	[TestClass]
	public class GetProductsListQueryTest
	{
		private GetProductsListQuery _query;
		private AutoMoqer _mocker;

		private const int ProductId = 1;
		private const string ProductName = "AfterShave";
		private const decimal ProductUnitPrice = 1.23m;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_query = _mocker.Create<GetProductsListQuery>();

			var product = new Product
			{
				Id = ProductId,
				Name = ProductName,
				Price = ProductUnitPrice
			};

			var productList = new List<Product> { product };
			_mocker.GetMock<IProductRepository>()
				.Setup(pr => pr.GetAll()).Returns(productList.AsQueryable());
		}

		[TestMethod]
		public void CallExecuteReturnsProductList()
		{
			var products = _query.Execute();
			var product = products.Single();
			Assert.IsNotNull(products);
			Assert.AreEqual(product.Id, ProductId);
			Assert.AreEqual(product.Name, ProductName);
			Assert.AreEqual(product.UnitPrice, ProductUnitPrice);
		}
	}
}
