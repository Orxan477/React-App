using Education.Core.Interfaces;
using Education.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Education.Data.Implementations
{
    internal class Repository<T>: IRepository<T>
          where T : class
    {
        private AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> Get(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = GetQuery(includes);

            return await query.Where(exp).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> exp = null, params string[] includes)
        {
            var query = GetQuery(includes);

            return exp is null
                ? await query.ToListAsync()
                : await query.Where(exp).ToListAsync();
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        private IQueryable<T> GetQuery(string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }
    }
}
