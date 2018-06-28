using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sales.Queries.GetSaleDetail
{
    public interface IGetSaleDetailQuery
    {
	    SaleDetailModel Execute(int id);
    }
}
