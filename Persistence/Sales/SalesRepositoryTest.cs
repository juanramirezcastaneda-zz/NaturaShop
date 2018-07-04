using AutoMoqCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Sales
{
	[TestClass]
	public class SalesRepositoryTest
	{
		private AutoMoqer _mocker;
		private SalesRepository _repository;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_repository = _mocker.Create<SalesRepository>();
		}

		[TestMethod]
		public void CallConstructorReturnsNotNull()
		{
			var expectedType = typeof(SalesRepository);
			var type = _repository.GetType();
			Assert.IsNotNull(type);
			Assert.AreEqual(type, expectedType);
		}
	}
}
