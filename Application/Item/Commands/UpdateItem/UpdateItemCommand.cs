using Application.Abstractions.Messaging;

namespace Application.Item.Commands.UpdateItem
{
    public class UpdateItemCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }

        public double Price { get; set; }
    }
}
