using Domain.Products;
using System;
using System.Collections.Generic;

namespace Application.Sales.Queries.GetSaleDetail
{
	public class SaleDetailModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public string CustomerName { get; set; }

		public string PartnerName { get; set; }

		public uint PartnerPhoneNumber { get; set; }

		public List<ProductSaleDetailModel> Products { get; set; }

		public decimal TotalSalePrice { get; set; }
	}
}
