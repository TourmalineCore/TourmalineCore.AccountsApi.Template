using System.Threading.Tasks;
using UserManagementService.Application.Users;

namespace UserManagementService.Application.RabbitMq.Producers;

public interface ICreatedUserProducer
{
    Task ProduceAsync(UserDto user, string password);
}