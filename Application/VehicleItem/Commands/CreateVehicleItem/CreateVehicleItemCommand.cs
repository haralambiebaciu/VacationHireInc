using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.VehicleItem.Commands.CreateVehicleItem
{
    public class CreateVehicleItemCommand : ICommand<Guid>
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleType VehicleType { get; set; }

        public Guid ItemId { get; set; }
    }
}
