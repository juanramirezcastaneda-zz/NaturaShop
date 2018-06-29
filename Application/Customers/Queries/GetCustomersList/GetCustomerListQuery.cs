using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;

namespace Application.Customers.Queries.GetCustomersList
{
	public class GetCustomerListQuery : IGetCustomerListQuery
	{
		private readonly ICustomerRepository _customerRepository;

		public GetCustomerListQuery(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public List<CustomerModel> Execute()
		{
			var customers = _customerRepository.GetAll().Select(ctr => new CustomerModel
			{
				Id = ctr.Id,
				Name = ctr.Name,
				PhoneNumber = ctr.PhoneNumber
			});

			return customers.ToList();
		}
	}
}
