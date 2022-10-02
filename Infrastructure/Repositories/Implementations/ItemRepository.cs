using Domain.Abstractions;
using Domain.Entities.Items;

namespace Infrastructure.Repositories.Implementations
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
