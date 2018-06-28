using System.Linq;
using Application.Interfaces;
using Application.Interfaces.Persistence;

namespace Application.Sales.Queries.GetSaleDetail
{
	public class GetSaleDetailQuery : IGetSaleDetailQuery
	{
		private readonly ISalesRepository _salesRepository;

		public GetSaleDetailQuery(ISalesRepository salesRepository)
		{
			_salesRepository = salesRepository;
		}

		public SaleDetailModel Execute(int saleId)
		{
			var saleDetail = _salesRepository.GetAll().Where(s => s.Id == saleId)
				.Select(sale => new SaleDetailModel
				{
					Id = sale.Id,
					Date = sale.Date,
					PartnerName = sale.Partner.Name,
					PartnerPhoneNumber = sale.Partner.PhoneNumber,
					CustomerName = sale.Customer.Name,
					ProductName = sale.Product.Name,
					Quantity = sale.Quantity,
					UnitPrice = sale.UnitPrice,
					TotalPrice = sale.TotalPrice
				}).Single();

			return saleDetail;
		}
	}
}
