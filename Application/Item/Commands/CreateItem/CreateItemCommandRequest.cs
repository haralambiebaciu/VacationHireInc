using Domain.Enums;

namespace Application.Item.Commands.CreateItem
{
    public class CreateItemCommandRequest
    {
        public double Price { get; set; }

        public ItemType ItemType { get; set; }
    }
}
