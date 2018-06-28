using Domain.Customers;
using Domain.Partners;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDatabaseService
    {
		DbSet<Customer> Customers { get; set; }

	    DbSet<Partner> Partners { get; set; }

	    DbSet<Product> Products { get; set; }

	    DbSet<Sale> Sales { get; set; }
		
		void Save();
    }
}
