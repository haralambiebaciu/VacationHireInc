using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Customer.Queries.GetAllCustomers
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IEnumerable<CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return (await _customerRepository.GetAsync()).Select(s => new CustomerResponse
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
            }).ToList();
        }
    }
}
