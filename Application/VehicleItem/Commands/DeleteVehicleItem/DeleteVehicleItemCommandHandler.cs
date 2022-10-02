using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.VehicleItem.Commands.DeleteVehicleItems
{
    public class DeleteVehicleItemCommandHandler : ICommandHandler<DeleteVehicleItemCommand, Guid>
    {
        private readonly IVehicleItemRepository _vehicleItemRepository;

        public DeleteVehicleItemCommandHandler(IVehicleItemRepository vehicleItemRepository)
        {
            _vehicleItemRepository = vehicleItemRepository;
        }

        public async Task<Guid> Handle(DeleteVehicleItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleItemRepository.DeleteAsync(request.Id);

            return entity.ItemId;
        }
    }
}
