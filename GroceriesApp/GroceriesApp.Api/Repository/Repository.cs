
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GroceriesAppDb _db;
        private readonly DbSet<T> _table;

        public Repository(GroceriesAppDb db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
