using Domain.Abstractions;
using Domain.Entities.Items;

namespace Infrastructure.Repositories.Implementations
{
    public class VehicleItemRepository: BaseRepository<VehicleItem>, IVehicleItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
