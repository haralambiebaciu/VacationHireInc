using Domain.Entities.Bills;

namespace Domain.Entities
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }

        public override void CopyFrom(Entity entity)
        {
            var user = (User)entity;

            Id = user.Id;
            Name = user.Name;
        }
    }
}
