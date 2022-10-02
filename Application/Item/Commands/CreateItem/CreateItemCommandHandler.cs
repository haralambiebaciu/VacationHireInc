using Entities = Domain.Entities.Items;

using Application.Abstractions.Messaging;
using Application.Item.Commands.CreateItem;
using Domain.Abstractions;

namespace Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand, Guid>
    {
        private readonly IItemRepository _itemRepository;
        public CreateItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = new Entities.Item(Guid.NewGuid())
            {
                Price = request.Price,
                Type = request.Type
            };
            
            await _itemRepository.InsertAsync(item);

            return item.Id;
        }
    }
}
