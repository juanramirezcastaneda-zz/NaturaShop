using Application.Interfaces.Persistence;
using Domain.Partners;
using Persistence.Shared;

namespace Persistence.Partners
{
	public class PartnersRepository : Repository<Partner>, IPartnersRepository
	{
		public PartnersRepository(IDatabaseContext database)
			: base(database) { }
	}
}
