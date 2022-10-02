using Application.Abstractions.Messaging;

namespace Application.Order.Queries.GetAllOrders
{
    public class GetOrdersQuery : IQuery<IEnumerable<OrderResponse>>
    {
    }
}
