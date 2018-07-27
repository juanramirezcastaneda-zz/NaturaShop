using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Sales;

namespace Domain.Products
{
    public class Product : IEntity
    {
        private decimal _price;
        private int _quantity;
        private decimal _totalPrice;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                UpdateTotalPrice();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdateTotalPrice();
            }
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            private set => _totalPrice = value;
        }

        public List<SaleProduct> SaleProducts { get; set; }

        private void UpdateTotalPrice()
        {
            _totalPrice = _quantity * _price;
        }
    }
}
