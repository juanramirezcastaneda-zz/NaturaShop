using System.Collections.Generic;
using System.Linq;
using Application.Partners.Queries.GetPartnersList;
using Microsoft.AspNetCore.Mvc;


namespace NaturaShop.Controllers
{
	[Produces("application/json")]
	[Route("api/Partners")]
	public class PartnersController : Controller
	{
		private readonly IGetPartnersListQuery _query;

		public PartnersController(IGetPartnersListQuery query)
		{
			_query = query;
		}

		[HttpGet]
		public IEnumerable<PartnerModel> GetAll()
		{
			return _query.Execute();
		}

		// Export logic to action in the repository
		[HttpGet("{id}")]
		public PartnerModel GetById(int id)
		{
			return _query.Execute().Single(pm => pm.Id == id);
		}
	}
}