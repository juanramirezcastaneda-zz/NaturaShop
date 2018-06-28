namespace Application.Sales.Commands.CreateSale
{
	public class CreateSaleModel
	{
		public int CustomerId { get; set; }

		public int PartnerId { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }
	}
}