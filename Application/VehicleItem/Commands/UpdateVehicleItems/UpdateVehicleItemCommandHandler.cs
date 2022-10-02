using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.VehicleItem.Commands.UpdateVehicleItems
{
    public class UpdateVehicleItemCommandHandler : ICommandHandler<UpdateVehicleItemCommand, Guid>
    {
        private readonly IVehicleItemRepository _vehicleItemRepository;

        public UpdateVehicleItemCommandHandler(IVehicleItemRepository vehicleItemRepository)
        {
            _vehicleItemRepository = vehicleItemRepository;
        }

        public async Task<Guid> Handle(UpdateVehicleItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleItemRepository.GetByIdAsync(request.Id);

            if (!string.IsNullOrEmpty(request.Model))
            {
                entity.Model = request.Model;
            }

            if (!string.IsNullOrEmpty(request.Brand))
            {
                entity.Brand = request.Brand;
            }

            await _vehicleItemRepository.UpdateAsync(request.Id, entity);

            return entity.ItemId;
        }
    }
}
