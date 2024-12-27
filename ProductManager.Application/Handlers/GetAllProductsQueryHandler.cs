using AutoMapper;
using MediatR;
using ProductManager.Application.Queries;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Handlers
{
	public class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQuery, IEnumerable<GetProductByIdResponse>>
	{
		private readonly IRepository<Product> _produtoRepository;
		private readonly IMapper _mapper;
		public GetAllProductsQueryHandler(IRepository<Product> produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<GetProductByIdResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var produtos = await _produtoRepository.GetAllAsync();

			/*return produtos.Select(produto => new GetProductByIdResponse
			{
				Id = produto.Id,
				Name = produto.Name,
				Price = produto.Price,
				AmountStock = produto.Stock.Amount
			});*/

			return _mapper.Map<IEnumerable<GetProductByIdResponse>>(produtos);
		}
	}
}
