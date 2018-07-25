using System;
using Domain.Common;
using Domain.Products;

namespace Domain.Sales
{
    public class SaleProduct
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}