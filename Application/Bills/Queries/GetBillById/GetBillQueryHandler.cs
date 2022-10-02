using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Bills.Queries.GetBillById
{
    public class GetBillQueryHandler : IQueryHandler<GetBillQuery, BillResponse>
    {
        private readonly IBillRepository _billRepository;

        public GetBillQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<BillResponse> Handle(GetBillQuery request, CancellationToken cancellationToken)
        {
            var entity = await _billRepository.GetByIdAsync(request.Id);

            return new BillResponse
            {
                BillId = entity.Id,
                Price = entity.Price,
                CustomerId = entity.CustomerId,
                OrderId = entity.OrderId,
                UserId = entity.UserId,
                Currency = entity.Currency
            };
        }
    }
}
