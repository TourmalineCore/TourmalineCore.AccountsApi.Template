using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace UserManagementService.Infrastructure.RabbitMq
{
    public class RabbitMqConsumer : IDisposable
    {
        private readonly ILogger<RabbitMqConsumer> _logger;

        private readonly object _mutex = new();
        private readonly IModel _channel;

        public event Func<string, ulong, IDictionary<string, object>, Task> OnNewMessage;

        public RabbitMqConsumer(
            PersistentConnection connection,
            ILogger<RabbitMqConsumer> logger)
        {
            _channel = connection.CreateChannel();
            _logger = logger;
        }

        public void Listen(string queueName)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += OnConsumerReceivedAsync;
            consumer.Shutdown += OnConsumerShutdownAsync;

            _channel.BasicConsume(queueName, false, consumer);

            _logger.LogInformation($"Start consume: {queueName}.");
        }

        public void ConfirmMessage(ulong deliveryTag)
        {
            lock (_mutex)
            {
                _channel.BasicAck(deliveryTag, false);
            }
        }

        public void RejectMessage(ulong deliveryTag, bool requeue = false)
        {
            lock (_mutex)
            {
                _channel.BasicReject(deliveryTag, requeue);
            }
        }

        private Task OnConsumerReceivedAsync(object sender, BasicDeliverEventArgs eventArgs)
        {
            var messageBody = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(messageBody);

            OnNewMessage.Invoke(message, eventArgs.DeliveryTag, eventArgs.BasicProperties.Headers);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _channel?.Close();
            }
        }

        private Task OnConsumerShutdownAsync(object sender, ShutdownEventArgs @event)
        {
            _logger.LogInformation("Consumer was shutdown {ReasonShutdown}", @event.ReplyText);
            return Task.CompletedTask;
        }
    }
}