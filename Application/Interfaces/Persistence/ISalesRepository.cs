using Domain.Sales;

namespace Application.Interfaces.Persistence
{
	public interface ISalesRepository : IRepository<Sale>
	{
		void Save();
	}
}
