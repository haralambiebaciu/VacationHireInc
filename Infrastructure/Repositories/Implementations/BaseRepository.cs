using Domain;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var context = _dbContext.Set<T>();
            var entity = await context.FindAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            context.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool? descending = null,
            string includeProperties = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                if (descending.HasValue && descending.Value)
                {
                    query = query.OrderByDescending(orderBy);
                }
                else
                {
                    query = query.OrderBy(orderBy);
                }
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.ToList();
        }

        public async Task<T> GetByIdAsync(Guid id, string includeProperties = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            var entity = query.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception();
            }

            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T entityToUpdate)
        {
            var context = _dbContext.Set<T>();
            var entity = await context.FindAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.CopyFrom(entityToUpdate);

            context.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
