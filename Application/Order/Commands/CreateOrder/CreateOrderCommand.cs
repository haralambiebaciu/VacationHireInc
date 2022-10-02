using Application.Abstractions.Messaging;

namespace Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand<Guid>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ItemId { get; set; }

        public Guid UserId { get; set; }

        public Guid CustomerId { get; set; }

    }
}
