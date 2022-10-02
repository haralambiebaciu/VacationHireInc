namespace Domain.Entities.Bills
{
    public class VehicleBill : Entity
    {
        public VehicleBill(Guid id) : base(id)
        {
        }

        public bool IsTankEmpty { get; set; }

        public bool IsCarDamaged { get; set; }


        public Guid BillId { get; set; }

        public virtual Bill Bill { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var vehicleBill = (VehicleBill)entity;

            Id = vehicleBill.Id;
            IsCarDamaged = vehicleBill.IsCarDamaged;
            IsTankEmpty = vehicleBill.IsTankEmpty;
        }
    }
}
