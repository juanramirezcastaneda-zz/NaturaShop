using Application.Interfaces.Persistence;
using Persistence.Shared;

namespace Persistence.Customer
{
	public class CustomerRepository
		: Repository<Domain.Customers.Customer>,
			ICustomerRepository
	{
		public CustomerRepository(IDatabaseContext database)
			: base(database) { }
	}
}
