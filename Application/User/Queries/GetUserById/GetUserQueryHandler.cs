using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.User.Queries.GetUserById
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(request.Id);

            return new UserResponse
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
