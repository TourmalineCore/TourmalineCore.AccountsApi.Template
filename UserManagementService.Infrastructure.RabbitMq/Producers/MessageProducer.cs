using Microsoft.Extensions.Options;
using UserManagementService.Infrastructure.RabbitMq.Contracts;
using UserManagementService.Infrastructure.RabbitMq.Options;

namespace UserManagementService.Infrastructure.RabbitMq.Producers
{
    public class MessageProducer : IMessageProducer
    {
        private readonly RabbitMqProducer _rabbitDownloadProducer;
        private readonly DlxOptions _dlxOptions;

        public MessageProducer(
            RabbitMqProducer rabbitDownloadProducer,
            IOptions<DlxOptions> dlxOptions)
        {
            _rabbitDownloadProducer = rabbitDownloadProducer;
            _dlxOptions = dlxOptions.Value;
        }

        public Task PublishTotallyDeadMessage(string message)
        {
            return _rabbitDownloadProducer.PublishToQueueAsync(message, _dlxOptions.TotallyDeadLettersQueueName);
        }
    }
}