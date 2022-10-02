using Application.Abstractions.Messaging;

namespace Application.Bills.Commands.UpdateBill
{
    public class UpdateBillCommand: ICommand<Guid>
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public string Currency { get; set; }
    }
}
