using Application.Abstractions.Messaging;
using Application.Bills.VehicleBill.Queries;

namespace Application.VehicleBill.Queries.GetVehicleBill
{
    public class GetVehicleBillQuery: IQuery<VehicleBillResponse>
    {
        public Guid Id { get; set; }
    }
}
