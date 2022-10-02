using Application.Item.Queries;
using Domain.Enums;

namespace Application.VehicleItem.Queries
{
    public class VehicleItemResponse: ItemResponse
    {
        public Guid VehicleId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleType VehicleType { get; set; }

    }
}
