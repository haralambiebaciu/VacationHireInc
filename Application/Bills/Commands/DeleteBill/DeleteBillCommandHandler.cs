using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandHandler : ICommandHandler<DeleteBillCommand, Guid>
    {
        private readonly IBillRepository _billRepository;

        public DeleteBillCommandHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<Guid> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            await _billRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
