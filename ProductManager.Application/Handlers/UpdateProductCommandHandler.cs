using MediatR;
using ProductManager.Application.Commands;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;
using System.Text.Json;

namespace ProductManager.Application.Handlers
{
	public class UpdateProductCommandHandler: IRequestHandler<UpdateProductCommand, bool>
	{
		private readonly IRepository<Product> _produtoRepository;
		private readonly IServiceBusProducer _serviceBusProducer;

		public UpdateProductCommandHandler(IRepository<Product> produtoRepository, IServiceBusProducer serviceBusProducer)
		{
			_produtoRepository = produtoRepository;
			_serviceBusProducer = serviceBusProducer;
		}

		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _produtoRepository.GetByIdAsync(request.Id);

			if(product == null)
				return false;

			product.UpdatePrice(request.Price);
			product.Stock.Add(request.StockAmount - product.Stock.Amount);
			await _produtoRepository.UpdateAsync(product);

			var eventSend = new
			{
				ProdutoId = product.Id,
				Nome = product.Name,
				Preco = product.Price,
				QuantidadeEstoque = product.Stock.Amount,
				Evento = "ProdutoAtualizado"
			};

			var message = JsonSerializer.Serialize(eventSend);
			await _serviceBusProducer.SendMessageAsync("produto-eventos", message);

			return true;
		}
	}
}
