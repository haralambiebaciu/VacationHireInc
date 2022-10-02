using Entities = Domain.Entities;

using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Entities.Customer(Guid.NewGuid())
            {
                Name = request.Name,
                Phone = request.Phone,
            };

            await _customerRepository.InsertAsync(customer);

            return customer.Id;
        }
    }
}
