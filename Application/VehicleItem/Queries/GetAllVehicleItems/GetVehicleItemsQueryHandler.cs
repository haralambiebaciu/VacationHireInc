using Application.Abstractions.Messaging;
using Domain.Abstractions;

using Entities = Domain.Entities.Items;

namespace Application.VehicleItem.Queries.GetAllVehicleItems
{
    public class GetVehicleItemsQueryHandler : IQueryHandler<GetVehicleItemsQuery, IEnumerable<VehicleItemResponse>>
    {
        private readonly IVehicleItemRepository _vehicleItemRepository;

        public GetVehicleItemsQueryHandler(IVehicleItemRepository vehicleItemRepository)
        {
            _vehicleItemRepository = vehicleItemRepository;
        }

        public async Task<IEnumerable<VehicleItemResponse>> Handle(GetVehicleItemsQuery request, CancellationToken cancellationToken)
        {
            return (await _vehicleItemRepository.GetAsync(includeProperties:nameof(Entities.VehicleItem.Item))).Select(u => new VehicleItemResponse
            {
                ItemId = u.Item.Id,
                Price = u.Item.Price,
                ItemType = u.Item.Type,
                VehicleId = u.Id,
                VehicleType = u.Type,
                Brand = u.Brand,
                Model = u.Model,
            }).ToList();
        }
    }
}
