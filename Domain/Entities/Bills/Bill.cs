namespace Domain.Entities.Bills
{
    public class Bill : Entity
    {
        public Bill(Guid id) : base(id)
        {
        }

        public double Price { get; set; }

        public string Currency { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual VehicleBill VehicleBill { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var bill = (Bill)entity;

            Id = bill.Id;
            Price = bill.Price;
            OrderId = bill.OrderId;
            UserId = bill.UserId;
            CustomerId = bill.CustomerId;
            Currency = bill.Currency;
        }
    }
}
