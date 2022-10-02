using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.VehicleItem.Commands.UpdateVehicleItems
{
    public class UpdateVehicleItemCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleType Type { get; set; }
    }
}
