using System.Threading.Tasks;
using UserManagementService.Application.RabbitMq.Producers;
using UserManagementService.Application.Users.Commands;

namespace UserManagementService.Application.Users;

public class CreatedUserHandler
{
    private readonly ICreatedUserProducer _createdUserProducer;
    private readonly CreateUserCommandHandler _createUserCommandHandler;

    public CreatedUserHandler(
        ICreatedUserProducer createdUserProducer,
        CreateUserCommandHandler createUserCommandHandler)
    {
        _createdUserProducer = createdUserProducer;
        _createUserCommandHandler = createUserCommandHandler;
    }

    public async Task<long> HandleNewUser(CreateUserCommand createUserCommand)
    {
        var userId = await _createUserCommandHandler.Handle(createUserCommand);

        var userDto = new UserDto(
            userId,
            createUserCommand.Name,
            createUserCommand.Surname,
            createUserCommand.Email,
            createUserCommand.RoleId
        );
        await _createdUserProducer.ProduceAsync(userDto, createUserCommand.Password);

        return userId;
    }
}