using System.Collections.Generic;

namespace Application.Sales.Commands.CreateSale
{
	public class CreateSaleModel
	{
		public int CustomerId { get; set; }

		public int PartnerId { get; set; }

		public List<int> ProductIds { get; set; }

		public int Quantity { get; set; }
	}
}