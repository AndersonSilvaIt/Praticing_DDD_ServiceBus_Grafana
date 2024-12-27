namespace ProductManager.Domain.Entities
{
	public class Product: BaseEntity
	{
		public string Name { get; private set; }
		public decimal Price { get; private set; }
		public Stock Stock { get; private set; }

		public Product(string name, decimal price, Stock stock)
		{
			Name = name;
			Price = price;
			Stock = stock ?? throw new ArgumentNullException(nameof(stock));
		}

		public void UpdatePrice(decimal newPrice)
		{
			if(newPrice <= 0)
				throw new ArgumentException("O preço deve ser maior que zero.");

			Price = newPrice;
			Update();
		}
	}

	public class Stock
	{
		public int Amount { get; private set; }

		public Stock(int amount)
		{
			if(amount < 0)
				throw new ArgumentException("A amount não pode ser negativa.");

			Amount = amount;
		}

		public void Add(int amount)
		{
			Amount += amount;
		}

		public void Remove(int amount)
		{
			if(Amount < amount)
				throw new InvalidOperationException("Quantidade insuficiente em estoque.");

			Amount -= amount;
		}
	}
}
