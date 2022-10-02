using Application.Abstractions.Messaging;

namespace Application.Order.Queries.GetOrderById
{
    public class GetOrderQuery : IQuery<OrderResponse>
    {
        public Guid Id { get; set; }
    }
}
