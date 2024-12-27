using MediatR;
using ProductManager.Application.Commands;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Handlers
{
	public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, bool>
	{
		private readonly IRepository<Product> _produtoRepository;

		public UpdateProductCommandHandler(IRepository<Product> produtoRepository)
		{
			_produtoRepository = produtoRepository;
		}

		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _produtoRepository.GetByIdAsync(request.Id);

			if(product == null)
				return false;

			product.UpdatePrice(request.Price);
			product.Stock.Add(request.StockAmount - product.Stock.Amount);
			await _produtoRepository.UpdateAsync(product);

			return true;
		}
	}
}
