using AutoMoqCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Products
{
	[TestClass]
	public class ProductsRepositoryTest
	{
		private AutoMoqer _mocker;
		private ProductsRepository _repository;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_repository = _mocker.Create<ProductsRepository>();
		}

		[TestMethod]
		public void CallConstructorReturnsNotNull()
		{
			var expectedType = typeof(ProductsRepository);
			var type = _repository.GetType();
			Assert.IsNotNull(type);
			Assert.AreEqual(type, expectedType);
		}
	}
}
