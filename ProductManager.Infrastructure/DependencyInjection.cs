using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Domain.Interfaces;
using ProductManager.Infrastructure.Context;
using ProductManager.Infrastructure.Repositories;

namespace ProductManager.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=productManager.db"));
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			return services;
		}
	}
}