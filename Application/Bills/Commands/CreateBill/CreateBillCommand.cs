using Application.Abstractions.Messaging;

namespace Application.Bills.Commands.CreateBill
{
    public class CreateBillCommand : ICommand<Guid>
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public Guid CustomerId { get; set; }

        public string Currency { get; set; }

    }
}
