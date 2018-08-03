using System;
using Domain.Common;
using Domain.Products;

namespace Domain.Sales
{
    public class SaleProduct
    {
        private Product _product;
        private decimal _totalProductPrice;
        private int _quantity;

        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdateProductTotalPrice();
            }
        }
        public decimal TotalProductPrice
        {
            get => _totalProductPrice;
            set
            {
                _totalProductPrice = value;
            }
        }
        public Sale Sale { get; set; }

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                UpdateProductTotalPrice();
            }
        }

        private void UpdateProductTotalPrice()
        {
            _totalProductPrice = Quantity * _product.UnitPrice;
        }
    }
}