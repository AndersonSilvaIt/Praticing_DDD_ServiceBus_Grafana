using MediatR;
using ProductManager.Application.Commands;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Handlers
{
	public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Guid>
	{
		private readonly IRepository<Product> _produtoRepository;

		public CreateProductCommandHandler(IRepository<Product> produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var estoque = new Stock(request.StockAmount);
			var product = new Product(request.Name, request.Price, estoque);

			await _produtoRepository.AddAsync(product);

			return product.Id;
		}
	}
}
