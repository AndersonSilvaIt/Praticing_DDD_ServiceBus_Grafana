namespace ProductManager.Domain.Entities
{
	public abstract class BaseEntity
	{
		public Guid Id { get; protected set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		protected BaseEntity()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
			UpdatedAt = DateTime.UtcNow;
		}

		public void Update()
		{
			UpdatedAt = DateTime.UtcNow;
		}
	}
}