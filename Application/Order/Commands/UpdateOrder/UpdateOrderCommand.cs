using Application.Abstractions.Messaging;

namespace Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
