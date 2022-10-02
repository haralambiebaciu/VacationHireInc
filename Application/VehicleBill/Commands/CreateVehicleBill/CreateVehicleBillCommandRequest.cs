using Application.Bills.Commands.CreateBill;

namespace Application.VehicleBill.Commands.CreateVehicleBill
{
    public class CreateVehicleBillCommandRequest: CreateBillCommandRequest
    {
        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }
    }
}
