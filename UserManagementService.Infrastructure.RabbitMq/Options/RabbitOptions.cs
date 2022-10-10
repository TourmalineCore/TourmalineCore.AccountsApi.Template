namespace UserManagementService.Infrastructure.RabbitMq.Options
{
    public class RabbitOptions
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public uint PrefetchSize { get; set; }

        public ushort PrefetchCount { get; set; }

        public string VirtualHost { get; set; }
    }
}