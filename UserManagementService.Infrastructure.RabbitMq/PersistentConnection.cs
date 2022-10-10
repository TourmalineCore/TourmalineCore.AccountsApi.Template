using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserManagementService.Infrastructure.RabbitMq.Options;

namespace UserManagementService.Infrastructure.RabbitMq
{
    public class PersistentConnection
    {
        private readonly ILogger<PersistentConnection> _logger;
        private readonly object _mutex = new();
        private readonly RabbitOptions _rabbitOptions;
        private volatile IAutorecoveringConnection _connection;
        private volatile bool _disposed;

        public PersistentConnection(
            IOptions<RabbitOptions> rabbitOptions,
            ILogger<PersistentConnection> logger)
        {
            _logger = logger;
            _rabbitOptions = rabbitOptions.Value;
        }

        public IModel CreateChannel()
        {
            var connection = _connection;

            if (connection == null)
            {
                lock (_mutex)
                {
                    _logger.LogInformation($"Try to connect to {_rabbitOptions.HostName}:{_rabbitOptions.Port}");
                    _logger.LogTrace(
                        $"With creds username: {_rabbitOptions.UserName}, password: {_rabbitOptions.Port}");

                    connection = _connection ??= Connect();
                }
            }

            if (!connection.IsOpen)
            {
                throw new Exception("Attempt to create a channel while rabbit was disconnected.");
            }

            var channel = connection.CreateModel();
            channel.BasicQos(_rabbitOptions.PrefetchSize, _rabbitOptions.PrefetchCount, false);

            return channel;
        }

        private IAutorecoveringConnection Connect()
        {
            var connection = (IAutorecoveringConnection)new ConnectionFactory
            {
                HostName = _rabbitOptions.HostName,
                VirtualHost = _rabbitOptions.VirtualHost,
                UserName = _rabbitOptions.UserName,
                Password = _rabbitOptions.Password,
                AutomaticRecoveryEnabled = true,
                DispatchConsumersAsync = true,
                RequestedHeartbeat = TimeSpan.FromSeconds(60)
            }.CreateConnection();

            if (connection == null)
            {
                throw new NotSupportedException("Non-recoverable connection is not supported");
            }

            _logger.LogInformation("Rabbit's connection created");

            connection.ConnectionShutdown += OnConnectionShutdown;
            connection.ConnectionBlocked += OnConnectionBlocked;
            connection.ConnectionUnblocked += OnConnectionUnblocked;
            connection.RecoverySucceeded += OnConnectionRecovered;

            return connection;
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            var connection = (IConnection)sender;

            _logger.LogInformation("Rabbit disconnected from broker {host}:{port} because of {reason}",
                connection.Endpoint.HostName,
                connection.Endpoint.Port,
                e.ReplyText
            );
        }

        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            _logger.LogInformation("Rabbit's connection blocked with reason {reason}", e.Reason);
        }

        private void OnConnectionUnblocked(object sender, EventArgs e)
        {
            _logger.LogInformation("Rabbit's connection unblocked");
        }

        private void OnConnectionRecovered(object sender, EventArgs e)
        {
            var connection = (IConnection)sender;

            _logger.LogInformation("Rabbit reconnected to broker {host}:{port}",
                connection.Endpoint.HostName,
                connection.Endpoint.Port
            );
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _connection?.Dispose();
            _disposed = true;
        }
    }
}