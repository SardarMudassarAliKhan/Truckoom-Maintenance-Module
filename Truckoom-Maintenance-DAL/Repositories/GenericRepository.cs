using Microsoft.EntityFrameworkCore;
using Truckoom_Maintenance.Data;
using Truckoom_Maintenance_DAL.IRepositories;
using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance_DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(string UserId)
        {
            return await _context.Set<T>().Where(act=>act.UpdatedBy == UserId).ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task IGenericRepository<T>.Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        Task IGenericRepository<T>.Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        
    }
}