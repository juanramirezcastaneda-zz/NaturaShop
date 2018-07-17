using System.Collections.Generic;
using System.Linq;
using Application.Customers.Queries.GetCustomersList;
using Microsoft.AspNetCore.Mvc;


namespace NaturaShop.Controllers
{
	[Produces("application/json")]
	[Route("api/Customers")]
	public class CustomersController : Controller
	{
		private readonly IGetCustomerListQuery _query;

		public CustomersController(IGetCustomerListQuery query)
		{
			_query = query;
		}

		[HttpGet]
		public IEnumerable<CustomerModel> GetAll()
		{
			return _query.Execute();
		}

		// Export logic to action in the repository
		[HttpGet("{id}")]
		public CustomerModel GetById(int id)
		{
			return _query.Execute().Single(cm => cm.Id == id);
		}
	}
}