namespace UserManagementService.Infrastructure.RabbitMq.Extensions
{
    public static class HeadersExtensions
    {
        public static long GetRetryCount(this IDictionary<string, object> headers)
        {
            if (headers == null)
            {
                return 0;
            }

            if (!headers.ContainsKey("x-death"))
            {
                return 0;
            }

            var deathProperties = (List<object>)headers["x-death"];

            if (deathProperties.Count == 0)
            {
                return 0;
            }

            var lastRetry = (Dictionary<string, object>)deathProperties[0];

            if (!lastRetry.ContainsKey("count"))
            {
                return 0;
            }

            return (long)lastRetry["count"];
        }
    }
}