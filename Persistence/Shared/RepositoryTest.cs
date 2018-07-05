using System;
using System.Collections.Generic;
using System.Linq;
using AutoMoqCore;
using Domain.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Shared
{
	[TestClass]
	public class RepositoryTest
	{
		private AutoMoqer _mocker;
		private Repository<Customer> _customerRepository;
		private Customer _customer;
		private InMemoryDbSet<Customer> _customersSet;

		private const int CustomerId = 1;
		private const string CustomerName = "Juan";
		private const uint CustomerPhoneNumber = 1;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();

			_customer = new Customer
			{
				Id = CustomerId,
				Name = CustomerName,
				PhoneNumber = CustomerPhoneNumber
			};

			_customersSet = new InMemoryDbSet<Customer> { _customer };

			_mocker.GetMock<IDatabaseContext>()
				.Setup(dbc => dbc.Set<Customer>()).Returns(_customersSet);

			_customerRepository = _mocker.Create<Repository<Customer>>();
		}

		[TestMethod]
		public void CallGetAllShouldReturnEntities()
		{
			var customers = _customerRepository.GetAll();
			Assert.IsNotNull(customers);
			var isCustomerInCollection =
				((InMemoryDbSet<Customer>)customers).Local.Contains(_customer);
			Assert.IsTrue(isCustomerInCollection);
		}
	}
}
