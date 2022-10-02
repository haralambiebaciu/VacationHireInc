using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Bills.Queries.GetAllBills
{
    public class GetBillsQueryHandler : IQueryHandler<GetBillsQuery, IEnumerable<BillResponse>>
    {
        private readonly IBillRepository _billRepository;

        public GetBillsQueryHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<IEnumerable<BillResponse>> Handle(GetBillsQuery request, CancellationToken cancellationToken)
        {
            return (await _billRepository.GetAsync()).Select(x => new BillResponse
            {
                BillId = x.Id,
                Price = x.Price,
                CustomerId = x.CustomerId,
                OrderId = x.OrderId,
                UserId = x.UserId,
                Currency = x.Currency,
            });
        }
    }
}
