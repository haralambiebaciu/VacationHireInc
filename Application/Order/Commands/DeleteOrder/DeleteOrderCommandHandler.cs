using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
