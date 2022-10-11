using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UserManagementService.Application.RabbitMq.Messages;
using UserManagementService.Application.Users;
using UserManagementService.Application.Utils;
using UserManagementService.Infrastructure.RabbitMq.Contracts;

namespace UserManagementService.Application.RabbitMq.Producers;

public class CreatedUserProducer : ICreatedUserProducer
{
    private readonly ILogger<CreatedUserProducer> _logger;
    private readonly IMessageProducer _messageProducer;

    public CreatedUserProducer(
        IMessageProducer messageProducer,
        ILogger<CreatedUserProducer> logger)
    {
        _messageProducer = messageProducer;
        _logger = logger;
    }

    public async Task ProduceAsync(UserDto user, string password)
    {
        var createdUserMessage = new CreatedUserMessage
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Password = password,
        };

        try
        {
            await _messageProducer.PublishCreatedUserAsync(CustomJsonSerializer.Serialize(createdUserMessage));

            _logger.LogDebug($"Publish created user for register in auth service witt email [{user.Email}]");
        }
        catch (Exception ex)
        {
            _logger.LogError($"[{nameof(CreatedUserProducer)}]: Could not publish created user message with email [{user.Email}]. Exception message: [{ex.Message}]");
        }
    }
}