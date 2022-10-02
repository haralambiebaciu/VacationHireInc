using Domain.Entities.Bills;
using Domain.Entities.Items;

namespace Domain.Entities
{
    public class Order : Entity
    {
        public Order(Guid id) : base(id)
        {
        }

        public DateTime StardDate { get; set; }

        public DateTime EndDate { get; set; }


        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Bill Bill { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var order = (Order)entity;

            Id = order.Id;
            StardDate = order.StardDate;
            EndDate = order.EndDate;
            ItemId = order.ItemId;
            UserId = order.UserId;
            CustomerId = order.CustomerId;
        }
    }
}
