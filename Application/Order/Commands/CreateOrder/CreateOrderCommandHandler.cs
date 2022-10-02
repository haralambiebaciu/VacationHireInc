using Entities = Domain.Entities;

using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var existingOrdersCount = (await _orderRepository.GetAsync(x => x.ItemId == request.ItemId &&
            ((x.StardDate <= request.StartDate && request.StartDate <= x.EndDate) || (x.StardDate <= request.EndDate && request.EndDate <= x.EndDate))))
            .Count();

            if(existingOrdersCount > 0)
            {
                throw new Exception($"Item already booked in period {request.StartDate} and {request.EndDate}");
            }    

            var order = new Entities.Order(Guid.NewGuid())
            {
                StardDate = request.StartDate,
                EndDate = request.EndDate,
                CustomerId = request.CustomerId,
                UserId = request.UserId,
                ItemId = request.ItemId,
            };

            await _orderRepository.InsertAsync(order);

            return order.Id;
        }
    }
}
