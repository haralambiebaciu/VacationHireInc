using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IBaseRepository<T> where T: class
    {

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool? descending = null,
            string includeProperties = null);

        Task<T> GetByIdAsync(Guid id, string includeProperties = null);

        Task<T> InsertAsync(T entity);

        Task<T> DeleteAsync(Guid id);

        Task<T> UpdateAsync(Guid id, T entityToUpdate);
    }
}
