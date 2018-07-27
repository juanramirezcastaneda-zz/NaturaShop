using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Customers;
using Domain.Partners;
using Domain.Products;

namespace Domain.Sales
{
    public class Sale : IEntity
    {
        private List<SaleProduct> _saleProducts;

        private decimal _totalPrice;

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Partner Partner { get; set; }

        public List<SaleProduct> SaleProducts
        {
            get => _saleProducts;
            set
            {
                _saleProducts = value;
                UpdateTotalPrice();
            }
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            private set => _totalPrice = value;
        }
        
        private void UpdateTotalPrice()
        {
            _totalPrice = 0;
            _saleProducts.ForEach(sp => {
                _totalPrice += sp.Product.TotalPrice;
            });
        }
    }
}
