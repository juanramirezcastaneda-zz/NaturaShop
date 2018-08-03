using System.Collections.Generic;

namespace Application.Sales.Commands.CreateSale
{
	public class CreateSaleModel
	{
		public int CustomerId { get; set; }

		public int PartnerId { get; set; }

		public Dictionary<int, int> ProductIdsQuantities { get; set; }
	}
}