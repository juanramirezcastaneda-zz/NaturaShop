﻿using System;

namespace Application.Sales.Queries.GetSaleDetail
{
	public class SaleDetailModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public string CustomerName { get; set; }

		public string PartnerName { get; set; }

		public uint PartnerPhoneNumber { get; set; }

		public string ProductName { get; set; }

		public decimal UnitPrice { get; set; }

		public int Quantity { get; set; }

		public decimal TotalPrice { get; set; }
	}
}