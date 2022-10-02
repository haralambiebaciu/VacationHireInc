using Application.Abstractions.Messaging;

namespace Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerQuery : IQuery<CustomerResponse>
    {
        public Guid Id { get; set; }
    }
}
