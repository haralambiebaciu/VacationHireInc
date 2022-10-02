using Application.Abstractions.Messaging;

namespace Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand<Guid>
    {
        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
