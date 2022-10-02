using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Item.Queries.GetAllItems
{
    public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, IEnumerable<ItemResponse>>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemsQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemResponse>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return (await _itemRepository.GetAsync()).Select(u => new ItemResponse
            {
                ItemId = u.Id,
                Price = u.Price,
                ItemType = u.Type,
            }).ToList();
        }
    }
}
