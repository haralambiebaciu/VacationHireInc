using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Item.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : ICommandHandler<UpdateItemCommand, Guid>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _itemRepository.GetByIdAsync(request.Id);

            if (request.Price != default)
            {
                entity.Price = request.Price;
            }
            
            await _itemRepository.UpdateAsync(request.Id, entity);

            return request.Id;
        }
    }
}
