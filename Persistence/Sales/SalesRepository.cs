using Application.Interfaces.Persistence;
using Domain.Sales;
using Persistence.Shared;

namespace Persistence.Sales
{
    public class SalesRepository : Repository<Sale>, ISalesRepository
    {
	    public SalesRepository(IDatabaseContext database) : base(database)
	    {
	    }
    }
}
