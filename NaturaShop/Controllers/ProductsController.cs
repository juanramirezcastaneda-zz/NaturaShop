using System.Collections.Generic;
using System.Linq;
using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;


namespace NaturaShop.Controllers
{
	[Produces("application/json")]
	[Route("api/Products")]
	public class ProductsController : Controller
	{
		private readonly IGetProductsListQuery _query;

		public ProductsController(IGetProductsListQuery query)
		{
			_query = query;
		}

		[HttpGet]
		public IEnumerable<ProductModel> GetAll()
		{
			return _query.Execute();
		}

		[HttpGet("{id}")]
		public ProductModel GetById(long id)
		{
			return _query.Execute().Single(pm => pm.Id == id);
		}
	}
}