using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagementService.Infrastructure.RabbitMq.Options;

namespace UserManagementService.Infrastructure.RabbitMq;

public class DependencyInjection
{
    public static IServiceCollection RegisterRabbitInfrastructure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<RabbitMqProducer>();
        services.AddSingleton<RabbitMqResourceCreator>();
        services.AddSingleton<PersistentConnection>();
        services.AddTransient<RabbitMqConsumer>();

        services.Configure<RabbitOptions>(configuration.GetSection(nameof(RabbitOptions)));
        services.Configure<QueueOptions>(configuration.GetSection(nameof(QueueOptions)));
        services.Configure<DlxOptions>(configuration.GetSection(nameof(DlxOptions)));

        return services;
    }

    public static void RegisterRabbitResources(IServiceCollection services, IConfiguration configuration)
    {
        var queueOptions = configuration.GetSection(nameof(QueueOptions)).Get<QueueOptions>();
        var dlxOptions = configuration.GetSection(nameof(DlxOptions)).Get<DlxOptions>();

        var serviceProvider = services.BuildServiceProvider();
        var rabbitMqResourceCreator = serviceProvider.GetRequiredService<RabbitMqResourceCreator>();

        rabbitMqResourceCreator.DeclareDlx(dlxOptions);

        rabbitMqResourceCreator.DeclareQueue(
                queueOptions.CreatedUsersQueueName,
                true,
                true,
                dlxOptions.DeadLetterExchangeName,
                queueOptions.CreatedUsersQueueName
            );
    }
}