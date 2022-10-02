using Application.Abstractions.Messaging;

namespace Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
