using Application.Abstractions.Messaging;

namespace Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
