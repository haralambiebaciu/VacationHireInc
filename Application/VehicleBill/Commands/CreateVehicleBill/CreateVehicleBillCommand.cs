using Application.Abstractions.Messaging;

namespace Application.VehicleBill.Commands.CreateVehicleBill
{
    public class CreateVehicleBillCommand: ICommand<Guid>
    {
        public Guid BillId { get; set; }

        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }
    }
}
