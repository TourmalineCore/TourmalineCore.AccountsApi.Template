using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace UserManagementService.Infrastructure.RabbitMq
{
    public class RabbitMqProducer : IDisposable
    {
        private readonly ILogger<RabbitMqProducer> _logger;

        private readonly object _mutex = new();
        private readonly IModel _channel;
        private readonly IBasicProperties _channelProperties;

        public RabbitMqProducer(
            PersistentConnection connection,
            ILogger<RabbitMqProducer> logger)
        {
            var channel = connection.CreateChannel();
            var properties = channel.CreateBasicProperties();

            properties.DeliveryMode = 2;
            properties.Persistent = true;

            _logger = logger;
            _channel = channel;
            _channelProperties = properties;
        }

        public Task PublishToQueueAsync(string message, string queueName)
        {
            var body = Encoding.UTF8.GetBytes(message);

            BasicPublishToQueue(body, queueName);

            _logger.LogDebug($"[Message data: {message}]: Publish new message to: {queueName}. With body length: {body.Length}.");

            return Task.CompletedTask;
        }

        private void BasicPublishToQueue(byte[] body, string queueName)
        {
            lock (_mutex)
            {
                _channel.BasicPublish(string.Empty,
                        queueName,
                        true,
                        _channelProperties,
                        body
                    );
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _channel?.Close();
            }
        }
    }
}