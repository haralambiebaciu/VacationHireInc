using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Customer.Queries.GetCustomerById
{
    public class GetCustomersQueryHandler : IQueryHandler<GetCustomerQuery, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetByIdAsync(request.Id);
            
            return new CustomerResponse 
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone
            };
        }
    }
}
