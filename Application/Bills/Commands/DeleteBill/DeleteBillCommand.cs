using Application.Abstractions.Messaging;

namespace Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
