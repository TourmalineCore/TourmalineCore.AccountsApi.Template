using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserListQuery : IRequest<IEnumerable<User>>
    {
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<User>>
        {
            private readonly IUserRepository _userRepository;

            public GetUserListQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public Task<IEnumerable<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                return _userRepository.GetAllAsync();
            }
        }
    }
}
