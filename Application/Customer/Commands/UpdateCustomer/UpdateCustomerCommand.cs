using Application.Abstractions.Messaging;

namespace Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
