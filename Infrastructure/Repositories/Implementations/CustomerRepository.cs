using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
