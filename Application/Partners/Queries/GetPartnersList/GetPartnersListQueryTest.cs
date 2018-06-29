using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMoqCore;
using Domain.Partners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Partners.Queries.GetPartnersList
{
	[TestClass]
	public class GetPartnersListQueryTest
	{
		private GetPartnersListQuery _query;
		private AutoMoqer _mocker;

		private const int PartnerId = 4;
		private const string PartnerName = "Lina";
		private const uint PartnerPhoneNumber = 3117336812;

		[TestInitialize]
		public void SetUp()
		{
			_mocker = new AutoMoqer();
			_query = _mocker.Create<GetPartnersListQuery>();

			var partner = new Partner
			{
				Id = PartnerId,
				Name = PartnerName,
				PhoneNumber = PartnerPhoneNumber
			};

			var partnerList = new List<Partner> { partner };
			_mocker.GetMock<IPartnersRepository>()
				.Setup(pr => pr.GetAll()).Returns(partnerList.AsQueryable());
		}

		[TestMethod]
		public void CallExecuteReturnsPartnerList()
		{
			var partners = _query.Execute();
			var partner = partners.Single();
			Assert.IsNotNull(partners);
			Assert.AreEqual(partner.Id, PartnerId);
			Assert.AreEqual(partner.Name, PartnerName);
			Assert.AreEqual(partner.PhoneNumber, PartnerPhoneNumber);
		}
	}
}