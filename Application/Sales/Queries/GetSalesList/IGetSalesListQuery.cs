using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
	    List<SalesListItemModel> Execute();
    }
}
