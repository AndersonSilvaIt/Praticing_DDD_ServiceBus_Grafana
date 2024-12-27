﻿using ProductManager.Domain.Entities;

namespace ProductManager.Domain.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(Guid id);
		Task<IEnumerable<T>> GetAllAsync();
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
