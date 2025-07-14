
using Microsoft.EntityFrameworkCore;
using Todo_Management_API.Models;

namespace Todo_Management_API.Repositries
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public AppDbContext db;
        public GenericRepository(AppDbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
           var entity = await db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public void  Update(T entity)
        {
           db.Set<T>().Update(entity);

        }
    }
}
