using Application.Abstractions.Messaging;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommand : ICommand<Guid>
    {
        public string Name { get; set; }
    }
}
