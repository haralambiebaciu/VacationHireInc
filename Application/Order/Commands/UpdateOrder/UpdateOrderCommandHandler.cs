using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            var existingOrdersCount = (await _orderRepository.GetAsync(x => x.ItemId == order.ItemId && x.Id != request.Id &&
            ((x.StardDate <= request.StartDate && request.StartDate <= x.EndDate) || (x.StardDate <= request.EndDate && request.EndDate <= x.EndDate))))
            .Count();


            if (existingOrdersCount > 0)
            {
                throw new Exception($"Item already booked in period {request.StartDate} and {request.EndDate}");
            }

            order.StardDate = request.StartDate;
            order.EndDate = request.EndDate;

            await _orderRepository.UpdateAsync(request.Id, order);

            return request.Id;
        }
    }
}
