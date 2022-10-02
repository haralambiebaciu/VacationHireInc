using Application.Bills.Commands.UpdateBill;

namespace Application.VehicleBill.Commands.UpdateVehicleBill
{
    public class UpdateVehicleBillCommandRequest : UpdateBillCommandRequest
    {
        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }
    }
}
