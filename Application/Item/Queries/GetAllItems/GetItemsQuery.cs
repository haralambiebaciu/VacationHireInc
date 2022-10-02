using Application.Abstractions.Messaging;

namespace Application.Item.Queries.GetAllItems
{
    public class GetItemsQuery : IQuery<IEnumerable<ItemResponse>>
    {
    }
}
