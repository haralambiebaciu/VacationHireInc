using Entities = Domain.Entities.Items;

using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.VehicleItem.Commands.CreateVehicleItem
{
    public class CreateVehicleItemCommandHandler : ICommandHandler<CreateVehicleItemCommand, Guid>
    {
        private readonly IVehicleItemRepository _itemVehicleRepository;
        public CreateVehicleItemCommandHandler(IVehicleItemRepository itemVehicleRepository)
        {
            _itemVehicleRepository = itemVehicleRepository;
        }

        public async Task<Guid> Handle(CreateVehicleItemCommand request, CancellationToken cancellationToken)
        {
            var vehicleItem = new Entities.VehicleItem(Guid.NewGuid())
            {
                Brand = request.Brand,
                Model = request.Model,
                Type = request.VehicleType,
                ItemId = request.ItemId
            };

            await _itemVehicleRepository.InsertAsync(vehicleItem);

            return vehicleItem.Id;
        }
    }
}
