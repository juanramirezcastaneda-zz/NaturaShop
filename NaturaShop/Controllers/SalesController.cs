using System.Collections.Generic;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;


namespace NaturaShop.Controllers
{
	[Produces("application/json")]
	[Route("api/Sales")]
	public class SalesController : Controller
	{
		private readonly IGetSalesListQuery _queryList;
		private readonly IGetSaleDetailQuery _queryDetail;

		public SalesController(IGetSalesListQuery queryList, 
			IGetSaleDetailQuery queryDetail)
		{
			_queryList = queryList;
			_queryDetail = queryDetail;
		}

		[HttpGet]
		public IEnumerable<SalesListItemModel> GetAll()
		{
			return _queryList.Execute();
		}

		// Export logic to action in the repository
		[HttpGet("{id}")]
		public SaleDetailModel GetById(int id)
		{
			return _queryDetail.Execute(id);
		}
	}
}