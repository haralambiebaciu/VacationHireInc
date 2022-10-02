using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Item.Queries.GetItemById
{
    public class GetItemQueryHandler : IQueryHandler<GetItemQuery, ItemResponse>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemResponse> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var entity = await _itemRepository.GetByIdAsync(request.Id);

            return new ItemResponse
            {
                ItemId = entity.Id,
                Price = entity.Price,
                ItemType = entity.Type
            };
        }
    }
}
