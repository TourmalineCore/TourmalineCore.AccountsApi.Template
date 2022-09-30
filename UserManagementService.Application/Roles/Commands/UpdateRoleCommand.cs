using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class UpdateRoleCommand
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Handle(UpdateRoleCommand request)
        {
            var role = await _roleRepository.FindOneAsync(request.Id);

            role.Update(request.Name);

            await _roleRepository.UpdateAsync(role);
        }
    }
}
