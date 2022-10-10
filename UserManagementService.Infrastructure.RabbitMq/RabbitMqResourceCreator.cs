using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using UserManagementService.Infrastructure.RabbitMq.Options;

namespace UserManagementService.Infrastructure.RabbitMq
{
    public class RabbitMqResourceCreator : IDisposable
    {
        private readonly ILogger<RabbitMqResourceCreator> _logger;

        private readonly IModel _channel;

        public RabbitMqResourceCreator(
            PersistentConnection connection,
            ILogger<RabbitMqResourceCreator> logger)
        {
            _channel = connection.CreateChannel();
            _logger = logger;
        }

        public void DeclareQueue(
            string queueName,
            bool durable = true,
            bool forceFlushOnDisk = true,
            string deadLetterExchange = "",
            string deadLetterRoutingKey = "",
            int messageTtlMs = 0)
        {
            var args = new Dictionary<string, object>();

            if (forceFlushOnDisk)
            {
                args["x-queue-mode"] = "lazy";
            }

            if (string.IsNullOrWhiteSpace(deadLetterExchange) == false)
            {
                args["x-dead-letter-exchange"] = deadLetterExchange;
            }

            if (string.IsNullOrWhiteSpace(deadLetterRoutingKey) == false)
            {
                args["x-dead-letter-routing-key"] = deadLetterRoutingKey;
            }

            if (messageTtlMs > 0)
            {
                args["x-message-ttl"] = messageTtlMs;
            }

            _channel.QueueDeclare(queueName,
                    true,
                    false,
                    false,
                    args
                );

            _logger.LogInformation($"Declared queue: {queueName}.");
        }

        public void BindQueueToExchange(string queueName, string exchangeName, string routingKey)
        {
            _channel.QueueBind(queueName, exchangeName, routingKey);

            _logger.LogInformation($"Bind queue [{queueName}] to exchange [{exchangeName}] by routing key [{routingKey}].");
        }

        public void DeclareExchange(string exchangeName, string exchangeType, bool durable = true)
        {
            _channel.ExchangeDeclare(exchangeName,
                    exchangeType,
                    durable
                );

            _logger.LogInformation($"Declared exchange: {exchangeName}.");
        }

        public void DeclareDlx(DlxOptions dlxOptions, bool durable = true)
        {
            _logger.LogInformation("Started declaring DLX circle.");

            DeclareQueue(
                    dlxOptions.TotallyDeadLettersQueueName,
                    durable
                );

            // Declare shared DLX
            DeclareExchange(
                    dlxOptions.DeadLetterExchangeName,
                    "fanout",
                    durable
                );

            // Declare shared retry exchange
            DeclareExchange(
                    dlxOptions.RetryExchangeName,
                    "direct",
                    durable
                );

            // Declare share queue for waiting for a timeout
            DeclareQueue(
                    dlxOptions.DelayedDeadLettersBeforeRetryQueueName,
                    durable,
                    true,
                    dlxOptions.RetryExchangeName,
                    "",
                    dlxOptions.DelayOfRetryMs
                );

            // Binding WaitingDeadLetterQueue to DeadLetterExchange by workerQueueName
            BindQueueToExchange(
                    dlxOptions.DelayedDeadLettersBeforeRetryQueueName,
                    dlxOptions.DeadLetterExchangeName,
                    ""
                );

            _logger.LogInformation("End of declaring DLX circle.");
        }

        public void Dispose()
        {
            _channel?.Close();
        }
    }
}