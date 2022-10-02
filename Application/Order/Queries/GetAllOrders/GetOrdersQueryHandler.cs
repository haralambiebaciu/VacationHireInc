using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Order.Queries.GetAllOrders
{
    public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return (await _orderRepository.GetAsync()).Select(s => new OrderResponse
            {
                Id = s.Id,
                EndDate = s.EndDate,
                StardDate = s.StardDate,
                ItemId = s.ItemId,
                CustomerId = s.CustomerId,
                UserId = s.UserId
            }).ToList();
        }
    }
}
