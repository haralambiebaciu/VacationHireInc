using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.User.Queries.GetAllUsers
{
    public class GetUsersQueryHandler: IQueryHandler<GetUsersQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return (await _userRepository.GetAsync()).Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
            }).ToList();
        }
    }
}
