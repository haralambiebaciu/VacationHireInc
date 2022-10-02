using Application.Abstractions.Messaging;

namespace Application.Bills.Queries.GetAllBills
{
    public class GetBillsQuery : IQuery<IEnumerable<BillResponse>>
    {
    }
}
