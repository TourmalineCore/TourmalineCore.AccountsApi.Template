using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Entities;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserByIdQuery : IRequest<User>
    {
        public long Id { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                return _userRepository.FindOneAsync(request.Id);
            }
        }
    }
}
