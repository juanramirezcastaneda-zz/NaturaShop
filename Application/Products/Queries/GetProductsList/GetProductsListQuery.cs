using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;

namespace Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery: IGetProductsListQuery
    {
	    private readonly IProductRepository _productRepository;

		public GetProductsListQuery(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public List<ProductModel> Execute()
		{
			var products = _productRepository.GetAll().Select(p => new ProductModel
			{
				Id = p.Id,
				Name = p.Name,
				UnitPrice = p.UnitPrice
			});

			return products.ToList();
		}
	}
}
