namespace ProductManager.Application.Queries
{
	public class GetProductByIdResponse
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int AmountStock { get; set; }
	}
}
