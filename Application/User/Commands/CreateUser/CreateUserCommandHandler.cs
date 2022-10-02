using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User(Guid.NewGuid())
            {
                Name = request.Name,
            };

            await _userRepository.InsertAsync(user);

            return user.Id;
        }
    }
}
