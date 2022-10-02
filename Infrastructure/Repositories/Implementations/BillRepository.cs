using Domain.Abstractions;
using Domain.Entities.Bills;

namespace Infrastructure.Repositories.Implementations
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
