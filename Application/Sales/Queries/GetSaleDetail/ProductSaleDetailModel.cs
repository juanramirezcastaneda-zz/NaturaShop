using Domain.Products;
using System;
using System.Collections.Generic;

namespace Application.Sales.Queries.GetSaleDetail
{
    public class ProductSaleDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
