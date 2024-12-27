using MediatR;

namespace ProductManager.Application.Commands
{
	public class UpdateProductCommand: IRequest<bool>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int StockAmount { get; set; }

		public UpdateProductCommand(Guid id, string name, decimal price, int amountStock)
		{
			Id = id;
			Name = name;
			Price = price;
			StockAmount = amountStock;
		}
	}
}
