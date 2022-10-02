using Application.Bills.Queries;

namespace Application.Bills.VehicleBill.Queries
{
    public class VehicleBillResponse : BillResponse
    {
        public Guid VehicleBillId { get; set; }

        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }
    }
}
