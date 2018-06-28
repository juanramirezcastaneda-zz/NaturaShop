using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;

namespace Application.Customers.Queries.GetCustomersList
{
	public class GetCustomerListQuery : IGetCustomerListQuery
	{
		private readonly IDatabaseService _database;

		public GetCustomerListQuery(IDatabaseService database)
		{
			_database = database;
		}

		public List<CustomerModel> Execute()
		{
			var customers = _database.Customers.Select(ctr => new CustomerModel
			{
				Id = ctr.Id,
				Name = ctr.Name,
				PhoneNumber = ctr.PhoneNumber
			});

			return customers.ToList();
		}
	}
}
