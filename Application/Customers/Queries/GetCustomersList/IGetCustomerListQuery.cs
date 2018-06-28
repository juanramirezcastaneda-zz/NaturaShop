using System.Collections.Generic;

namespace Application.Customers.Queries.GetCustomersList
{
	public interface IGetCustomerListQuery
	{
		List<CustomerModel> Execute();
	}
}
