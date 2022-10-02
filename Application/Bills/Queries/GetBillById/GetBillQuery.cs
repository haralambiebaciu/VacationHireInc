using Application.Abstractions.Messaging;

namespace Application.Bills.Queries.GetBillById
{
    public class GetBillQuery : IQuery<BillResponse>
    {
        public Guid Id { get; set; }
    }
}
