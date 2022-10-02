using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Item.Commands.CreateItem
{
    public class CreateItemCommand: ICommand<Guid>
    {
        public double Price { get; set; }

        public ItemType Type { get; set; }
    }
}
