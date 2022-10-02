using Application.Abstractions.Messaging;

namespace Application.VehicleBill.Commands.DeleteVehicleBill
{
    public class DeleteVehicleBillCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
