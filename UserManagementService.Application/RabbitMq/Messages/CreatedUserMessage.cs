namespace UserManagementService.Application.RabbitMq.Messages;

public class CreatedUserMessage
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

}