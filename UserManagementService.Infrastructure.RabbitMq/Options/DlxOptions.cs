namespace UserManagementService.Infrastructure.RabbitMq.Options
{
    public class DlxOptions
    {
        /// <summary>
        /// Имя Exchange для "dead letters"
        /// </summary>
        public string DeadLetterExchangeName { get; set; }

        /// <summary>
        /// Имя очереди задержки "dead letters" перед повторной попыткой
        /// </summary>
        public string DelayedDeadLettersBeforeRetryQueueName { get; set; }

        /// <summary>
        /// Имя Exchange роутинга сообщения в его очередь для повторной обработки
        /// </summary>
        public string RetryExchangeName { get; set; }

        /// <summary>
        /// Имя очереди полностью неудачно обортанных сообщений
        /// </summary>
        public string TotallyDeadLettersQueueName { get; set; }

        /// <summary>
        /// Количество повторых попыток обработки
        /// </summary>
        public int NumberOfRetryAttempts { get; set; }

        /// <summary>
        /// Задержка "dead letter" перед повторной обработкой
        /// </summary>
        public int DelayOfRetryMs { get; set; }
    }
}