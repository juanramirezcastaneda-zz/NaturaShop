using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Sales;
using Persistence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Sales
{
    public class SalesRepository : Repository<Sale>, ISalesRepository
    {
        private IDatabaseContext _database;
	    public SalesRepository(IDatabaseContext database) : base(database)
	    {
            _database = database;
	    }

        public override IQueryable<Sale> GetAll(){
            return _database.Sales.Include(s => s.SaleProducts);
        }

        public override Sale Get(int id){
            return _database.Sales
                .Include(s => s.Customer)
                .Include(s => s.Partner)
                .Include(s => s.SaleProducts)
                .ThenInclude(sp => sp.Product).First(s => s.Id == id);
        }

        public void Save(){
            _database.Save();
        }
    }
}
