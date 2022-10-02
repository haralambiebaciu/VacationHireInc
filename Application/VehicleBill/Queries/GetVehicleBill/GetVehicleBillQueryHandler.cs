using Application.Abstractions.Messaging;
using Application.Bills.VehicleBill.Queries;
using Domain.Abstractions;

using Entities = Domain.Entities.Bills;

namespace Application.VehicleBill.Queries.GetVehicleBill
{
    public class GetVehicleBillQueryHandler: IQueryHandler<GetVehicleBillQuery, VehicleBillResponse>
    {
        private readonly IVehicleBillRepository _vehicleBillRepository;

        public GetVehicleBillQueryHandler(IVehicleBillRepository vehicleBillRepository)
        {
            _vehicleBillRepository = vehicleBillRepository; 
        }

        public async Task<VehicleBillResponse> Handle(GetVehicleBillQuery request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleBillRepository.GetByIdAsync(request.Id, includeProperties: nameof(Entities.VehicleBill.Bill));

            return new VehicleBillResponse()
            {
                BillId = entity.Bill.Id,
                Currency = entity.Bill.Currency,
                Price = entity.Bill.Price,
                OrderId = entity.Bill.OrderId,
                UserId = entity.Bill.UserId,
                CustomerId = entity.Bill.CustomerId,
                VehicleBillId = entity.Id,
                IsCarDamaged = entity.IsCarDamaged,
                IsTankEmpty = entity.IsTankEmpty,
            };
        }
    }
}
