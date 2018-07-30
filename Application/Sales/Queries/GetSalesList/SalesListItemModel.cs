using System;
using System.Collections.Generic;
using Domain.Sales;

namespace Application.Sales.Queries.GetSalesList
{
	public class SalesListItemModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public string CustomerName { get; set; }

		public string PartnerName { get; set; }

		public uint PartnerPhoneNumber { get; set; }

		public decimal TotalPrice { get; set; }

		public int NumberOfProducts {get; set;}
	}
}
