using Domain.Enums;

namespace Domain.Entities.Items
{
    public class VehicleItem : Entity
    {
        public VehicleItem(Guid id) : base(id)
        {
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleType Type { get; set; }


        public Guid ItemId { get; set; }

        public virtual Item Item { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var vehicleItem = (VehicleItem)entity;

            Id = vehicleItem.Id;
            Brand = vehicleItem.Brand;
            Model = vehicleItem.Model;
            Type = vehicleItem.Type;
        }
    }
}
