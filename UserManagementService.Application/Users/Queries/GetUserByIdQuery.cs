using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Users.Queries
{
    public partial class GetUserByIdQuery
    {
        public long Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request)
        {
            var userEntity = await _userRepository.FindOneAsync(request.Id);

            return UserDto.MapFrom(userEntity);
        }
    }
}
