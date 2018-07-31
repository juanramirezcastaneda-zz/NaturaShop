using System;
using System.Linq;
using Application.Interfaces;
using Application.Interfaces.Persistence;
using Domain.Products;

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
			var saleDetail = _salesRepository.Get(saleId);
			var products = saleDetail.SaleProducts.Select(sp => new ProductSaleDetailModel{
				Id = sp.Product.Id,
				Name = sp.Product.Name,
				UnitPrice = sp.Product.UnitPrice,
				Quantity = sp.Quantity
			}).ToList();

			var saleDetailModel = new SaleDetailModel{
				Id = saleDetail.Id,
				Products = products,
				Date = saleDetail.Date,
				CustomerName = saleDetail.Customer.Name,
				PartnerName = saleDetail.Partner.Name,
				PartnerPhoneNumber = saleDetail.Partner.PhoneNumber,
				TotalSalePrice = saleDetail.TotalSalePrice
			};
			return saleDetailModel;
		}
	}
}
