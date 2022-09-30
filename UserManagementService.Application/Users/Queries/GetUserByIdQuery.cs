using System.Threading.Tasks;
using UserManagementService.Core.Entities;
using UserManagementService.Core.Contracts;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserByIdQuery
    {
        public long Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserByIdQuery request)
        {
            return _userRepository.FindOneAsync(request.Id);
        }
    }
}
