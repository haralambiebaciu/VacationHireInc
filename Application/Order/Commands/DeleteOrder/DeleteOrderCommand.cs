using Application.Abstractions.Messaging;

namespace Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
