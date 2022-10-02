using Application.Abstractions.Messaging;

namespace Application.VehicleItem.Queries.GetVehicleItemById
{
    public class GetVehicleItemQuery : IQuery<VehicleItemResponse>
    {
        public Guid Id { get; set; }
    }
}
