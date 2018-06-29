using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMoqCore;
using Domain.Customers;
using Domain.Partners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Customers.Queries.GetCustomersList
{
	[TestClass]
	public class GetCustomerListQueryTest 
	{
		private GetCustomerListQuery _query;
		private AutoMoqer _mocker;

		private const int CustomerId = 4;
		private const string CustomerName = "Lina";
		private const uint CustomerPhoneNumber = 3117336812;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_query = _mocker.Create<GetCustomerListQuery>();

			var customer = new Customer
			{
				Id = CustomerId,
				Name = CustomerName,
				PhoneNumber = CustomerPhoneNumber
			};

			var customerList = new List<Customer> { customer };
			_mocker.GetMock<ICustomerRepository>()
				.Setup(pr => pr.GetAll()).Returns(customerList.AsQueryable());
		}

		[TestMethod]
		public void CallExecuteReturnsPartnerList()
		{
			var customers = _query.Execute();
			var customer = customers.Single();
			Assert.IsNotNull(customers);
			Assert.AreEqual(customer.Id, CustomerId);
			Assert.AreEqual(customer.Name, CustomerName);
			Assert.AreEqual(customer.PhoneNumber, CustomerPhoneNumber);
		}
	}
}
