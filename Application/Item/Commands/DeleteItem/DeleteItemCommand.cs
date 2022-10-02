using Application.Abstractions.Messaging;

namespace Application.Item.Commands.DeleteItem
{
    public class DeleteItemCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
