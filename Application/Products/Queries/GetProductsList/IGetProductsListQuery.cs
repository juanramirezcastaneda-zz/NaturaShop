using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
	    List<ProductModel> Execute();
    }
}
