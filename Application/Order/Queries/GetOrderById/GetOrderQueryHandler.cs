using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Order.Queries.GetOrderById
{
    public class GetOrderQueryHandler : IQueryHandler<GetOrderQuery, OrderResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.GetByIdAsync(request.Id);

            return new OrderResponse
            {
                Id = entity.Id,
                EndDate = entity.EndDate,
                StardDate = entity.StardDate,
                ItemId = entity.ItemId,
                CustomerId = entity.CustomerId,
                UserId = entity.UserId
            };
        }
    }
}
