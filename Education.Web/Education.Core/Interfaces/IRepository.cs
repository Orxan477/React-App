using System.Linq.Expressions;

namespace Education.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> Get(Expression<Func<T, bool>> exp, params string[] includes);
        Task<List<T>> GetAll(Expression<Func<T, bool>> exp = null, params string[] includes);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
