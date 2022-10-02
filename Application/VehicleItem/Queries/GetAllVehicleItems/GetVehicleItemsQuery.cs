using Application.Abstractions.Messaging;

namespace Application.VehicleItem.Queries.GetAllVehicleItems
{
    public class GetVehicleItemsQuery : IQuery<IEnumerable<VehicleItemResponse>>
    {
    }
}
