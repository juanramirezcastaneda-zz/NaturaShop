using System.Collections.Generic;
using Application.Sales.Commands.CreateSale;
using Application.Sales.Commands.CreateSale.Factory;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
	[Produces("application/json")]
	[Route("api/Sales")]
	public class SalesController : Controller
	{
		private readonly IGetSalesListQuery _queryList;
		private readonly IGetSaleDetailQuery _queryDetail;
		private readonly ISaleFactory _saleFactory;
		private readonly ICreateSaleCommand _createSaleCommand;

		public SalesController(IGetSalesListQuery queryList, 
			IGetSaleDetailQuery queryDetail,
			ISaleFactory saleFactory,
			ICreateSaleCommand createSaleCommand)
		{
			_queryList = queryList;
			_queryDetail = queryDetail;
			_saleFactory = saleFactory;
			_createSaleCommand = createSaleCommand;
		}

		[HttpGet]
		public IEnumerable<SalesListItemModel> GetAll()
		{
			return _queryList.Execute();
		}

		[HttpGet("{id}")]
		public SaleDetailModel GetDetailById(int id)
		{
			return _queryDetail.Execute(id);
		}

		[HttpPost]
		public void CreateSale([FromBody] CreateSaleViewModel viewModel)
		{
			_createSaleCommand.Execute(viewModel.Sale);
		}
	}
}