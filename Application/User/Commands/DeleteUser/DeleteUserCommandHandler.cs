using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
