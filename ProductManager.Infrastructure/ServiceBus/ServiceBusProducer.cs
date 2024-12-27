using Azure.Messaging.ServiceBus;
using ProductManager.Application.Interfaces;

namespace ProductManager.Infrastructure.ServiceBus
{
	public class ServiceBusProducer: IServiceBusProducer
	{
		private readonly ServiceBusClient _client;

		public ServiceBusProducer(string connectionString)
		{
			_client = new ServiceBusClient(connectionString);
		}

		public async Task SendMessageAsync(string topicName, string message)
		{
			var sender = _client.CreateSender(topicName);

			try
			{
				var serviceBusMessage = new ServiceBusMessage(message);
				await sender.SendMessageAsync(serviceBusMessage);
			} finally
			{
				await sender.DisposeAsync();
			}
		}
	}
}
