using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        { 
            _dbContext = dbContext;
        }
    }
}
