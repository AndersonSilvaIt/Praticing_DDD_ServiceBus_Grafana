using MediatR;
using ProductManager.Application.Commands;
using ProductManager.Application.Interfaces;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Interfaces;
using System.Text.Json;

namespace ProductManager.Application.Handlers
{
	public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, Guid>
	{
		private readonly IRepository<Product> _produtoRepository;
		private readonly IServiceBusProducer _serviceBusProducer;
		public CreateProductCommandHandler(IRepository<Product> produtoRepository, IServiceBusProducer serviceBusProducer)
		{
			_produtoRepository = produtoRepository;
			_serviceBusProducer = serviceBusProducer;
		}

		public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var estoque = new Stock(request.StockAmount);
			var product = new Product(request.Name, request.Price, estoque);

			await _produtoRepository.AddAsync(product);

			var eventSend = new
			{
				ProdutoId = product.Id,
				Nome = product.Name,
				Preco = product.Price,
				QuantidadeEstoque = product.Stock.Amount,
				Evento = "ProdutoCriado"
			};

			var message = JsonSerializer.Serialize(eventSend);
			await _serviceBusProducer.SendMessageAsync("produto-eventos", message);

			return product.Id;
		}
	}
}