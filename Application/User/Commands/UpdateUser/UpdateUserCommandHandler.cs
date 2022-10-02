using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.User.Commands.UpdateUser
{
    public class UpdatUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public UpdatUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(request.Id);

            if (!string.IsNullOrEmpty(request.Name))
            {
                entity.Name = request.Name;
            }

            await _userRepository.UpdateAsync(request.Id, entity);

            return request.Id;
        }
    }
}
