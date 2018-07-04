using Application.Interfaces.Persistence;
using Domain.Products;
using Persistence.Shared;

namespace Persistence.Products
{
	public class ProductsRepository : Repository<Product>, IProductRepository
	{
		public ProductsRepository(IDatabaseContext database)
			: base(database) { }
	}
}
