using Application.Abstractions.Messaging;

namespace Application.Item.Queries.GetItemById
{
    public class GetItemQuery : IQuery<ItemResponse>
    {
        public Guid Id { get; set; }
    }
}
