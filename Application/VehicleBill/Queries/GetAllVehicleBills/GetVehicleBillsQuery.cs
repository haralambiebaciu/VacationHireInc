using Application.Abstractions.Messaging;
using Application.Bills.VehicleBill.Queries;

namespace Application.VehicleBill.Queries.GetAllVehicleBills
{
    public class GetVehicleBillsQuery: IQuery<IEnumerable<VehicleBillResponse>>
    {
    }
}
