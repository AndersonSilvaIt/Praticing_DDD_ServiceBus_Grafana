using MediatR;
using ProductManager.Application.Commands;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;

namespace ProductManager.Application.Handlers
{
	public class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, bool>
	{
		private readonly IRepository<Product> _productRepository;

		public DeleteProductCommandHandler(IRepository<Product> productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetByIdAsync(request.Id);

			if(product == null)
				return false;

			await _productRepository.DeleteAsync(product);
			return true;
		}
	}
}
