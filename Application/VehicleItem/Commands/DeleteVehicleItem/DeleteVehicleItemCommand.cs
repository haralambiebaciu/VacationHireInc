using Application.Abstractions.Messaging;

namespace Application.VehicleItem.Commands.DeleteVehicleItems
{
    public class DeleteVehicleItemCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
