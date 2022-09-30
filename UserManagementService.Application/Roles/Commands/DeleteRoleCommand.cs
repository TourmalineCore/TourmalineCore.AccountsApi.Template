using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class DeleteRoleCommand
    {
        public long Id { get; set; }
    }

    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;
        
        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        
        public async Task Handle(DeleteRoleCommand request)
        {
            var role = await _roleRepository.FindOneAsync(request.Id);
            await _roleRepository.RemoveAsync(role);
        }
    }
}
