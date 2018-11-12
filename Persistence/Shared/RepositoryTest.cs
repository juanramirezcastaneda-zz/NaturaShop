using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Shared
{
    [TestClass]
    public class RepositoryTest
    {
        private Repository<Customer> _customerRepository;
        private DatabaseContext _dbContext;
        private Customer _customer;
        private const int CustomerId = 1;
        private const string CustomerName = "Juan";
        private const uint CustomerPhoneNumber = 1;

        [TestInitialize]
        public void SetUp()
        {
            _customer = new Customer
            {
                Id = CustomerId,
                Name = CustomerName,
                PhoneNumber = CustomerPhoneNumber
            };

            var contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "Test_inmemory_database").Options;
            _dbContext = new DatabaseContext(contextOptions);
        }

        [TestMethod]
        public void CallAddShouldAddOneCustomer()
        {
            _customerRepository = new Repository<Customer>(_dbContext);
            _customerRepository.Add(_customer);

            var customer = _dbContext.Customers.Local.First();
            Assert.AreSame(customer, _customer);
        }
    }
}
