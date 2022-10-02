using Domain.Enums;

namespace Domain.Entities.Items
{
    public class Item : Entity
    {
        public Item(Guid id) : base(id)
        {
        }

        public double Price { get; set; }

        public ItemType Type { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public virtual VehicleItem VehicleItem { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var item = (Item)entity;

            Id = item.Id;
            Price = item.Price;
            Type = item.Type;
        }
    }
}
