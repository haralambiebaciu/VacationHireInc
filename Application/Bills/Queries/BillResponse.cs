namespace Application.Bills.Queries
{
    public class BillResponse
    {
        public Guid BillId { get; set; }

        public double Price { get; set; }

        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public Guid CustomerId { get; set; }

        public string Currency { get; set; }
    }
}
