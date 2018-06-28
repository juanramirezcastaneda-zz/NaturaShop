using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;

namespace Application.Sales.Commands.CreateSale
{
	public class CreateSaleCommand : ICreateSaleCommand
	{
		private readonly IDatabaseService _database;
		private readonly IDateService _dateService;
		private readonly ISaleFactory _saleFactory;
		private readonly IInventoryService _inventory;
		
		public CreateSaleCommand(IDatabaseService database, IInventoryService inventory,
			IDateService dateService, ISaleFactory saleFactory)
		{
			_database = database;
			_dateService = dateService;
			_saleFactory = saleFactory;
			_inventory = inventory;
		}

		public void Execute(CreateSaleModel model)
		{
			var date = _dateService.GetDate();
			var partner = _database.Partners.Single(p => p.Id == model.PartnerId);
			var customer = _database.Customers.Single(c => c.Id == model.CustomerId);
			var product = _database.Products.Single(p => p.Id == model.ProductId);
			var quantity = model.Quantity;

			var newSale = _saleFactory.Create(date, customer, partner, product, quantity);
			_database.Sales.Add(newSale);

			_database.Save();

			//_inventory.NotifySaleOcurred(product.Id, quantity);
		}
	}
}
