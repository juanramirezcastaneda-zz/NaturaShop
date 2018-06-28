using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.Interfaces.Persistence;

namespace Application.Sales.Queries.GetSalesList
{
	public class GetSalesListQuery : IGetSalesListQuery
	{
		private readonly ISalesRepository _salesRepository;

		public GetSalesListQuery(ISalesRepository salesRepository)
		{
			_salesRepository = salesRepository;
		}

		public List<SalesListItemModel> Execute()
		{
			var sales = _salesRepository.GetAll().Select(s => new SalesListItemModel
			{
				Id = s.Id,
				Date = s.Date,
				CustomerName = s.Customer.Name,
				PartnerName = s.Partner.Name,
				PartnerPhoneNumber = s.Partner.PhoneNumber,
				UnitPrice = s.UnitPrice,
				TotalPrice = s.TotalPrice,
				Quantity = s.Quantity
			});
			return sales.ToList();
		}
	}
}
