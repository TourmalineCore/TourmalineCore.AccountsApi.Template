using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserListQuery
    {
    }

    public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> Handle(GetUserListQuery request)
        {
            return _userRepository.GetAllAsync();
        }
    }
}
