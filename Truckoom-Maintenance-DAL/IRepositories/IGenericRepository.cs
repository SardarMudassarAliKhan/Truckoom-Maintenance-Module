using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance_DAL.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync(string UserId);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
