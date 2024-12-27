using MediatR;

namespace ProductManager.Application.Commands
{
	public class CreateProductCommand: IRequest<Guid>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int StockAmount { get; set; }

		public CreateProductCommand(string name, decimal price, int amountStock)
		{
			Name = name;
			Price = price;
			StockAmount = amountStock;
		}
	}
}
