using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Domain.Partners;

namespace Application.Partners.Queries.GetPartnersList
{
	public class GetPartnersListQuery : IGetPartnersListQuery
	{
		private readonly IDatabaseService _database;

		public GetPartnersListQuery(IDatabaseService database)
		{
			_database = database;
		}

		public List<PartnerModel> Execute()
		{
			var partners = _database.Partners.Select(ptn => new PartnerModel
			{
				Id = ptn.Id,
				Name = ptn.Name, 
				PhoneNumber = ptn.PhoneNumber
			});

			return partners.ToList();
		}
	}
}
