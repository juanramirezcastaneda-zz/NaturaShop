using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces;
using Application.Interfaces.Persistence;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;
using Domain.Products;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IPartnersRepository _partnersRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDateService _dateService;
        private readonly ISaleFactory _saleFactory;

        public CreateSaleCommand(ISalesRepository salesRepository,
            IPartnersRepository partnersRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IDateService dateService, ISaleFactory saleFactory)
        {
            _saleFactory = saleFactory;
            _customerRepository = customerRepository;
            _salesRepository = salesRepository;
            _partnersRepository = partnersRepository;
            _productRepository = productRepository;
            _dateService = dateService;
            _saleFactory = saleFactory;
        }

        public void Execute(CreateSaleModel model)
        {
            var date = _dateService.GetDate();
            var partner = _partnersRepository.Get(model.PartnerId);
            var customer = _customerRepository.Get(model.CustomerId);
            var products = new List<Product>();
            foreach (var productId in model.ProductIds)
            {
                var product = _productRepository.Get(productId);
                products.Add(product);
            }
  
            var newSale = _saleFactory.Create(date, customer,
             partner, products);
            _salesRepository.Add(newSale);

            //_database.Save();
        }
    }
}
