using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteAsync(request.Id);

            return request.Id;
        }
    }
}
