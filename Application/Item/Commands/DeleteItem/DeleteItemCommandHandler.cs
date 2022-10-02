using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Item.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : ICommandHandler<DeleteItemCommand, Guid>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            await _itemRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
