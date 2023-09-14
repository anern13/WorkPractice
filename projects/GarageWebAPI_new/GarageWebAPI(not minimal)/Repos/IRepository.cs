using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace GarageWebAPI_not_minimal_.Repos
{
    public interface IRepository<T>  where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> PostAsync(T entity);
        Task<T?> PutAsync(T entity, int id);
        Task<T?> DeleteAsync(int id);
        void SaveChangesAsync();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> DeleteAsync(int id)
        {
            var ret = await _context.Set<T>()
                                .FindAsync(id);
            if(ret is not null)
                _context.Set<T>().Remove(ret);
            await _context.SaveChangesAsync();

            return ret;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T?> PutAsync(T entity, int id)
        {
            var dbEntity = await _context.Set<T>().FindAsync(id);
            //dbEntity = entity;
            if(dbEntity is not null)
                _context.Set<T>().Update(dbEntity);

            return dbEntity;
        }

        public virtual async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> PostAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity;
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }  
}
    