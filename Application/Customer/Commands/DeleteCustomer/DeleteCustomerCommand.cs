using Application.Abstractions.Messaging;

namespace Application.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
