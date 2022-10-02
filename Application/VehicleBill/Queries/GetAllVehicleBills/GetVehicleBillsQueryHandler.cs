using Application.Abstractions.Messaging;
using Application.Bills.VehicleBill.Queries;
using Domain.Abstractions;

using Entities = Domain.Entities.Bills;

namespace Application.VehicleBill.Queries.GetAllVehicleBills
{
    public class GetVehicleBillsQueryHandler : IQueryHandler<GetVehicleBillsQuery, IEnumerable<VehicleBillResponse>>
    {
        private readonly IVehicleBillRepository _vehicleBillRepository;

        public GetVehicleBillsQueryHandler(IVehicleBillRepository vehicleBillRepository)
        {
            _vehicleBillRepository = vehicleBillRepository;
        }

        public async Task<IEnumerable<VehicleBillResponse>> Handle(GetVehicleBillsQuery request, CancellationToken cancellationToken)
        {
            return (await _vehicleBillRepository.GetAsync(includeProperties: nameof(Entities.VehicleBill.Bill))).Select(v => new VehicleBillResponse
            {
                BillId =  v.Bill.Id,
                Currency = v.Bill.Currency,
                Price = v.Bill.Price,
                OrderId = v.Bill.OrderId,
                UserId = v.Bill.UserId,
                CustomerId = v.Bill.CustomerId,
                VehicleBillId = v.Id,
                IsCarDamaged = v.IsCarDamaged,
                IsTankEmpty = v.IsTankEmpty,
            }).ToList();
        }
    }
}
