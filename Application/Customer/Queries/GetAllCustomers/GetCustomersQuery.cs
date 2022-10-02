using Application.Abstractions.Messaging;

namespace Application.Customer.Queries.GetAllCustomers
{
    public class GetCustomersQuery : IQuery<IEnumerable<CustomerResponse>>
    {
    }
}
