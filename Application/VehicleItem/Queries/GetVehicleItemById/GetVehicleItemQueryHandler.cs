using Entities = Domain.Entities.Items;

using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.VehicleItem.Queries.GetVehicleItemById
{
    public class GetVehicleItemQueryHandler : IQueryHandler<GetVehicleItemQuery, VehicleItemResponse>
    {
        private readonly IVehicleItemRepository _vehicleItemRepository;

        public GetVehicleItemQueryHandler(IVehicleItemRepository vehicleItemRepository)
        {
            _vehicleItemRepository = vehicleItemRepository;
        }

        public async Task<VehicleItemResponse> Handle(GetVehicleItemQuery request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleItemRepository.GetByIdAsync(request.Id, includeProperties: nameof(Entities.VehicleItem.Item));

            return new VehicleItemResponse
            {
                ItemId = entity.Item.Id,
                Price = entity.Item.Price,
                ItemType = entity.Item.Type,
                VehicleId = entity.Id,
                VehicleType = entity.Type,
                Brand = entity.Brand,
                Model = entity.Model,
            };
        }
    }
}
