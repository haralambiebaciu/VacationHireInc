using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.VehicleBill.Commands.DeleteVehicleBill
{
    public class DeleteVehicleBillCommandHandler : ICommandHandler<DeleteVehicleBillCommand, Guid>
    {
        private readonly IVehicleBillRepository _vehicleBillRepository;

        public DeleteVehicleBillCommandHandler(IVehicleBillRepository vehicleRepository)
        {
            _vehicleBillRepository = vehicleRepository;
        }

        public async Task<Guid> Handle(DeleteVehicleBillCommand request, CancellationToken cancellationToken)
        {
            var entity = await _vehicleBillRepository.DeleteAsync(request.Id);

            return entity.BillId;
        }
    }
}
