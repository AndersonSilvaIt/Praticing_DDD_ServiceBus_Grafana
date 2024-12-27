using AutoMapper;
using MediatR;
using ProductManager.Application.Queries;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Handlers
{
	public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
	{
		private readonly IRepository<Product> _produtoRepository;
		private readonly IMapper _mapper;

		public GetProductByIdQueryHandler(IRepository<Product> produtoRepository, IMapper mapper)
		{
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}

		public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var produto = await _produtoRepository.GetByIdAsync(request.Id);

			if(produto == null)
				return null;

			return _mapper.Map<GetProductByIdResponse>(produto);
		}
	}
}
