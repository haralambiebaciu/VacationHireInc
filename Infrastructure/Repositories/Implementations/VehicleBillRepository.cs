using Domain.Abstractions;
using Domain.Entities.Bills;

namespace Infrastructure.Repositories.Implementations
{
    public class VehicleBillRepository : BaseRepository<VehicleBill>, IVehicleBillRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleBillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
