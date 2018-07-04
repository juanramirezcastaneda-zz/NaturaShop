using AutoMoqCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Persistence.Partners
{
	[TestClass]
	public class PartnersRepositoryTest
	{
		private AutoMoqer _mocker;
		private PartnersRepository _repository;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_repository = _mocker.Create<PartnersRepository>();
		}

		[TestMethod]
		public void CallConstructorReturnsNotNull()
		{
			var expectedType = typeof(PartnersRepository);
			var type = _repository.GetType();
			Assert.IsNotNull(type);
			Assert.AreEqual(type, expectedType);
		}
	}
}
