using Application.Item.Commands.CreateItem;
using Domain.Enums;

namespace Application.VehicleItem.Commands.CreateVehicleItem
{
    public class CreateVehicleItemCommandRequest: CreateItemCommandRequest
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
