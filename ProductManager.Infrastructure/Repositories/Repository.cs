using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Infrastructure.Repositories
{
	public class Repository<T>: IRepository<T> where T : BaseEntity
	{
		private readonly DbContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(DbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
		public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
		public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
		public async Task UpdateAsync(T entity) => _dbSet.Update(entity);
		public async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
	}
}
