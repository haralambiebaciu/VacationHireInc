using Domain.Entities.Bills;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var customer = (Customer)entity;

            Id = customer.Id;
            Name = customer.Name;
            Phone = customer.Phone;
        }
    }
}
