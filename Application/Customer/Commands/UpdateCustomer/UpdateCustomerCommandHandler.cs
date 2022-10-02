using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetByIdAsync(request.Id);

            if (request.Name != null)
            {
                entity.Name = request.Name;
            }

            if (request.Phone != null)
            {
                entity.Phone = request.Phone;
            }

            await _customerRepository.UpdateAsync(request.Id, entity);

            return request.Id;
        }
    }
}
