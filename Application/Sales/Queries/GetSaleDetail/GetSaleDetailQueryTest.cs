using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMoqCore;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Serialization;

namespace Application.Sales.Queries.GetSaleDetail
{
	[TestClass]
	public class GetSaleDetailQueryTest
	{
		private GetSaleDetailQuery _query;
		private AutoMoqer _mocker;

		private const string PartnerName = "Lina";
		private const string CustomerName = "Juan";
		private const string ProductName = "Sunscreen";
		private const int PartnerId = 4;
		private const int ProductId = 1;
		private const int SaleId = 1;
		private const int CostumerId = 9;
		private const int SaleQuantity = 2;
		private const int ProductPrice = 10;
		private const decimal SaleTotalPrice = 10;
		private const uint PartnerPhoneNumber = 3117336812;
		private const uint CostumerPhoneNumber = 3103931978;
		private readonly DateTime _saleDateTime = new DateTime(2017, 9, 9);

		[TestInitialize]
		public void SetUp()
		{
			var partner = new Partner()
			{
				Id = PartnerId,
				Name = PartnerName,
				PhoneNumber = PartnerPhoneNumber
			};

            var product = new Product
            {
                Id = ProductId,
                Name = ProductName,
                UnitPrice = ProductPrice
            };

            var saleProducts = new List<SaleProduct>{
                new SaleProduct{
                    Product = product,
                    ProductId = product.Id,
					Quantity = 1,
					TotalProductPrice = product.UnitPrice * 1
                }
            };

            var costumer = new Customer
			{
				Id = CostumerId,
				Name = CustomerName,
				PhoneNumber = CostumerPhoneNumber
			};

			var sale = new Sale()
			{
				Id = SaleId,
				Partner = partner,
				SaleProducts = saleProducts,
				Date = _saleDateTime,
				Customer = costumer
			};

			_mocker = new AutoMoqer();
			_mocker.GetMock<ISalesRepository>()
				.Setup(sr => sr.Get(SaleId))
				.Returns(sale);
			_query = _mocker.Create<GetSaleDetailQuery>();
		}

		[TestMethod]
		public void CallExecuteReturnsSaleDetails()
		{
			var detailModel = _query.Execute(SaleId);
			Assert.IsNotNull(detailModel);
			Assert.AreEqual(detailModel.Id, SaleId);
			Assert.AreEqual(detailModel.Date, _saleDateTime);
			Assert.AreEqual(detailModel.CustomerName, CustomerName);
			Assert.AreEqual(detailModel.PartnerName, PartnerName);
			Assert.AreEqual(detailModel.PartnerPhoneNumber, PartnerPhoneNumber);
			Assert.AreEqual(detailModel.TotalSalePrice, SaleTotalPrice);
		}
	}
}
