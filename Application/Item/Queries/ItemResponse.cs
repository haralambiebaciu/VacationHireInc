using Domain.Enums;

namespace Application.Item.Queries
{
    public class ItemResponse
    {
        public Guid ItemId { get; set; }

        public double Price { get; set; }

        public ItemType ItemType { get; set; }
    }
}
