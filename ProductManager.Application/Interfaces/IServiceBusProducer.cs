namespace ProductManager.Application.Interfaces
{
	public interface IServiceBusProducer
	{
		Task SendMessageAsync(string topicName, string message);
	}
}
