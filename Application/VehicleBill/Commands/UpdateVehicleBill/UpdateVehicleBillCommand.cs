using Application.Abstractions.Messaging;

namespace Application.VehicleBill.Commands.UpdateVehicleBill
{
    public class UpdateVehicleBillCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }

        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }

        public Guid BillId { get; set; }
    }
}
