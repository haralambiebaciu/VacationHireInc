namespace Application.Order.Queries
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public DateTime StardDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ItemId { get; set; }

        public Guid UserId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
