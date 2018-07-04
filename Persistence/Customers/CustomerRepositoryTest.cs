using AutoMoqCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Customers
{
	[TestClass]
	public class CustomerRepositoryTest
	{
		private AutoMoqer _mocker;
		private CustomerRepository _repository;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_repository = _mocker.Create<CustomerRepository>();
		}

		[TestMethod]
		public void CallConstructorReturnsNotNull()
		{
			var expectedType = typeof(CustomerRepository);
			var type = _repository.GetType();
			Assert.IsNotNull(type);
			Assert.AreEqual(type, expectedType);
		}
	}
}
