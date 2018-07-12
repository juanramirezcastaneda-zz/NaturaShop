using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Common;

namespace Persistence.Shared
{
	public class Repository<T> : IRepository<T>
		where T : class, IEntity
	{
		private readonly IDatabaseContext _database;

		public Repository(IDatabaseContext database)
		{
			_database = database;
		}

		public IQueryable<T> GetAll()
		{
			return _database.Set<T>();
		}

		public T Get(int id)
		{
			return _database.Set<T>().Single(ent => ent.Id == id);
		}

		public void Add(T entity)
		{
			_database.Set<T>().Add(entity);
		}

		public void Remove(T entity)
		{
			_database.Set<T>().Remove(entity);
		}
	}
}
