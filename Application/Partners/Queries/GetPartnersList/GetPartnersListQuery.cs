using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;

namespace Application.Partners.Queries.GetPartnersList
{
	public class GetPartnersListQuery : IGetPartnersListQuery
	{
		private readonly IPartnersRepository _partnersRepository;

		public GetPartnersListQuery(IPartnersRepository partnersRepository)
		{
			_partnersRepository = partnersRepository;
		}

		public List<PartnerModel> Execute()
		{
			var partners = _partnersRepository.GetAll().Select(ptn => new PartnerModel
			{
				Id = ptn.Id,
				Name = ptn.Name, 
				PhoneNumber = ptn.PhoneNumber
			});

			return partners.ToList();
		}
	}
}
