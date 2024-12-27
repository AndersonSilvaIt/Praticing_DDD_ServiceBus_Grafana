using AutoMapper;
using ProductManager.Application.Queries;
using ProductManager.Domain.Entities;

namespace ProductManager.Application.Mappings
{
	public class ProductMappingProfile: Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<Product, GetProductByIdResponse>()
				.ForMember(dest => dest.AmountStock, opt => opt.MapFrom(src => src.Stock.Amount));
		}
	}
}