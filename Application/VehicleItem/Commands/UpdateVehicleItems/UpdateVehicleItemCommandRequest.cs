using Application.Item.Commands.UpdateItem;
using Domain.Enums;

namespace Application.VehicleItem.Commands.UpdateVehicleItems
{
    public class UpdateVehicleItemCommandRequest : UpdateItemCommandRequest
    {
        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
