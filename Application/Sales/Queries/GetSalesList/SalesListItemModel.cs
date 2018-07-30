using System;
using Application.Customers.Queries.GetCustomersList;
using Application.Partners.Queries.GetPartnersList;
using Application.Products.Queries.GetProductsList;

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
	}
}
