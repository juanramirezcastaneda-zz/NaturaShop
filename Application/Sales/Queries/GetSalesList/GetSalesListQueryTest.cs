using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.Sales.Queries.GetSalesList;
using AutoMoqCore;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Sales.Queries.GetSalesList
{
	[TestClass]
	public class GetSalesListQueryTest
	{
		private GetSalesListQuery _query;
		private AutoMoqer _mocker;

		private const int SaleId = 1;
		private const int CustomerId = 7;
		private const uint CustomerPhoneNumber = 3103931978;
		private const string CustomerName = "Juan";
		private const string PartnerName = "Lina";
		private const int PartnerId = 4;
		private const uint PartnerPhoneNumber = 3117336812;
		private readonly DateTime _saleDateTime = new DateTime(2017, 9, 9);
		private const string ProductName = "Sunscreen";
		private const int ProductId = 1;
		private const int ProductPrice = 10;
		private const int SaleQuantity = 2;
		// private const decimal SaleUnitPrice = 1.4m;
		private const decimal SaleTotalPrice = 2.8m;

		[TestInitialize]
		public void SetUp()
		{
			var product = new Product
			{
				Id = ProductId,
				Name = ProductName,
				Price = ProductPrice
			};
			
            var saleproducts = new List<SaleProduct>{
                new SaleProduct{
                    Product = product,
                    ProductId = product.Id
                }
            };

			var partner = new Partner()
			{
				Id = PartnerId,
				Name = PartnerName,
				PhoneNumber = PartnerPhoneNumber
			};

			var costumer = new Customer
			{
				Id = CustomerId,
				Name = CustomerName,
				PhoneNumber = CustomerPhoneNumber
			};

			var sale1 = new Sale
			{
				Id = SaleId,
				Partner = partner,
				Date = _saleDateTime,
				SaleProducts = saleproducts,
				Customer = costumer,
				Quantity = SaleQuantity
			};

			var saleList = new List<Sale> { sale1 };

			_mocker = new AutoMoqer();
			_mocker.GetMock<ISalesRepository>().Setup(sr =>
				sr.GetAll()).Returns(saleList.AsQueryable());
			_query = _mocker.Create<GetSalesListQuery>();
		}

		[TestMethod]
		public void CallExecuteReturnsSalesList()
		{
			const int expectedSalesCount = 1;
			var salesList = _query.Execute();
			var sale = salesList.Single();

			Assert.AreEqual(salesList.Count, expectedSalesCount);
			Assert.AreEqual(sale.Id, SaleId);
			Assert.AreEqual(sale.Date, _saleDateTime);
			Assert.AreEqual(sale.CustomerName, CustomerName);
			Assert.AreEqual(sale.Quantity, SaleQuantity);
			Assert.AreEqual(sale.PartnerName, PartnerName);
			Assert.AreEqual(sale.PartnerPhoneNumber, PartnerPhoneNumber);
			// Assert.AreEqual(sale.UnitPrice, SaleUnitPrice);
			Assert.AreEqual(sale.TotalPrice, SaleTotalPrice);
		}
	}
}
